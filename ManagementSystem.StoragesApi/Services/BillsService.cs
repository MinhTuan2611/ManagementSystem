﻿using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Functions;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class BillsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _context;
        private IConfiguration _configuration;
        private readonly string _path = string.Empty;
        private ResponseDto _responseDto;

        public BillsService(StoragesDbContext context, IConfiguration configuration)
        {
            _unitOfWork = new UnitOfWork(context);
            _configuration = configuration;
            _context = context;
            _responseDto = new ResponseDto();

            _path = @"C:\\Logs\\Bills";
        }

        public List<ListBillResponse> GetListBills()
        {
            string[] includes = { "Customer" };
            List<ListBillResponse> bills = _unitOfWork.BillRepository.GetWithInclude(x => true, includes).Select(bill => new ListBillResponse
            {
                BillId = bill.BillId,
                TotalAmount = bill.totalAmount,
                CustomerId = bill.CustomerId,
                CustomerName = bill.Customer != null ? bill.Customer!.CustomerName : string.Empty,
                CreateDate = bill.CreateDate,
            }).ToList();
            return bills;
        }

        public BillInfo CreateBill(BillInfo bill)
        {
            try
            {
                int billHour = DateTime.Now.Hour;
                int shiftId = 1;

                if (bill.ShiftId == null)
                {
                    var employeeShift = GetEmployeeShifts().FirstOrDefault(x => x.StartTime <= billHour && billHour <= x.EndTime);
                    if (employeeShift == null)
                    {
                        shiftId = 2;
                    }
                }
                else
                {
                    shiftId = bill.ShiftId.Value;
                }

                var newBill = new Bill
                {
                    BranchId = bill.BranchId,
                    totalAmount = bill.totalAmount,
                    totalPaid = bill.totalPaid,
                    totalChange = bill.totalChange,
                    CustomerId = bill.CustomerId,
                    PaymentStatus = PaymentStatus.UnPaid,
                    CreateBy = bill.UserId,
                    ModifyBy = bill.UserId,
                    ShiftId = shiftId
                };
                _unitOfWork.BillRepository.Insert(newBill);
                _unitOfWork.Save();
                bill.BillId = newBill.BillId;
                foreach (PaymentDetail detail in bill.Payments)
                {
                    var paymentMethod = _unitOfWork.PaymentMethodRepository.GetFirst(x => x.PaymentMethodCode == detail.PaymentMethodCode);
                    var newPaymentDetail = new BillPayment
                    {
                        BillId = newBill.BillId,
                        PaymentMethodId = paymentMethod.PaymentMethodId,
                        Amount = detail.Amount,
                        PaymentMethod = paymentMethod,
                        Bill = newBill,
                        PaymentStatus = PaymentStatus.UnPaid,
                    };
                    _unitOfWork.BillPaymentRepository.Insert(newPaymentDetail);
                    _unitOfWork.Save();
                    detail.Id = newPaymentDetail.Id;
                    detail.BillId = newBill.BillId;
                }
                foreach (BillDetailInfo detail in bill.Details)
                {
                    var product = _unitOfWork.ProductRepository.GetByID(detail.ProductId);
                    var unit = _unitOfWork.UnitRepository.GetByID(detail.UnitId);
                    var newDetail = new BillDetail
                    {
                        BillId = newBill.BillId,
                        ProductId = detail.ProductId,
                        UnitId = detail.UnitId,
                        DiscountAmount = detail.DiscountAmount,
                        DiscountPercentage = detail.DiscountPercentage,
                        DiscountByPercentage = detail.DiscountByPercentage,
                        Quantity = detail.Quantity,
                        Amount = detail.Amount,
                        Bill = newBill,
                        Product = product,
                        Unit = unit
                    };
                    var storage = _unitOfWork.StorageRepository.GetFirst(x => x.BranchId == (bill.BranchId ?? 1));
                    var quantityInStorage = _unitOfWork.ProductStorageRepository.Get(x => x.ProductId == detail.ProductId && x.StorageId == storage.StorageId);
                    if (quantityInStorage != null)
                    {
                        quantityInStorage.Quantity -= detail.Quantity;
                        _unitOfWork.ProductStorageRepository.Update(quantityInStorage);
                        _unitOfWork.Save();
                    }
                    _unitOfWork.BillDetailRepository.Insert(newDetail);
                    _unitOfWork.Save();
                    detail.Id = newDetail.Id;
                    detail.BillId = newDetail.BillId;
                }
                _unitOfWork.Dispose();
                return bill;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function Create Bills: " + ex.Message, _path);
                return null;
            }

        }
        public bool CompleteBill(BillInfo bill)
        {
            try
            {
                if (bill.BillId == null)
                {
                    return false;
                }
                var billData = _unitOfWork.BillRepository.GetByID(bill.BillId);
                billData.PaymentStatus = PaymentStatus.Paid;
                billData.IsAutoComplete = bill.IsAutoCompelte;
                _unitOfWork.BillRepository.Update(billData);
                _unitOfWork.Save();
                foreach (PaymentDetail detail in bill.Payments)
                {
                    var paymentMethod = _unitOfWork.PaymentMethodRepository.GetFirst(x => x.PaymentMethodCode == detail.PaymentMethodCode);
                    if (detail.Id != null)
                    {
                        var paymentDetail = _unitOfWork.BillPaymentRepository.GetByID(detail.Id);
                        paymentDetail.PaymentStatus = detail.PaymentStatus;
                        paymentDetail.Amount = detail.Amount;
                        _unitOfWork.BillPaymentRepository.Update(paymentDetail);
                        _unitOfWork.Save();
                    }
                    else
                    {
                        var newPaymentDetail = new BillPayment
                        {
                            BillId = bill.BillId ?? 0,
                            PaymentMethodId = paymentMethod.PaymentMethodId,
                            Amount = detail.Amount,
                            PaymentMethod = paymentMethod,
                            Bill = billData,
                            PaymentStatus = PaymentStatus.Paid,
                        };
                        _unitOfWork.BillPaymentRepository.Insert(newPaymentDetail);
                        _unitOfWork.Save();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CheckMomoPayment(MomoRequestIPN request)
        {
            var orderId = Int32.Parse(request.OrderId.Split('-').Last());
            var paymentMethod = _unitOfWork.PaymentMethodRepository.GetFirst(x => x.PaymentMethodCode == "MOMO");
            var payment = _unitOfWork.BillPaymentRepository.GetFirst(x => x.BillId == orderId && x.PaymentMethodId == paymentMethod.PaymentMethodId);
            if (payment.Amount != request.Amount)
            {
                return false;
            }
            return true;
        }

        public async Task<TPagination<BillSearchingResponseDto>> SearchBills(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);

                // Your DbContextFactory and DbContext creation code
                var dbContextFactory = new DbContextFactory(_configuration);
                using var dbContext = dbContextFactory.CreateDbContext<StoragesDbContext>("StoragesDbConnStr");

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@xmlString", xmlString )
                };

                int pageNumber = criteria.PageNumber <= 0 ? 1 : criteria.PageNumber;
                int pageSize = criteria.PageSize <= 0 ? 10 : criteria.PageSize;

                var executeResult = await GenericSearchRepository<BillSearchingResponseDto>.ExecutePagedStoredProcedureCommonAsync<BillSearchingResponseDto>
                                                                                    (dbContext, "sp_SearchBills", pageNumber, pageSize, parameters);

                // Process the results
                List<BillSearchingResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;


                var modifiedList = pagedData.Select(bill =>
                {
                    bill.CustomerName = bill.CustomerName == null ? "Khách Lẻ" : bill.CustomerName;
                    return bill;
                }).ToList();

                var result = new TPagination<BillSearchingResponseDto>();
                result.Items = modifiedList;
                result.TotalItems = totalRecords;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BillResponseDto> GetBillDetail(int billId)
        {
            var billDetails = await GetBillDetailHandler(billId);
            var billPayments = await GetBillPaymentMethods(billId);
            var billInformation = GetBillById(billId);
            var billResponse = new BillResponseDto();

            billResponse.BillId = billId;
            billResponse.totalChange = billInformation.totalChange;
            billResponse.totalPaid = billResponse.totalPaid;
            billResponse.totalAmount = billInformation.totalAmount;
            billResponse.CustomerId = billInformation?.CustomerId;
            billResponse.CustomerName = billInformation?.CustomerName;
            billResponse.CustomerCode = billInformation?.CustomerCode;
            billResponse.TotalBillAmount = billPayments.Sum(x => x.Amount.Value);
            billResponse.Details = billDetails;
            billResponse.Payments = billPayments;
            billResponse.UserName = billInformation?.UserName;
            billResponse.ShiftId = billInformation?.ShiftId;
            billResponse.ShiftName = billInformation?.ShiftName;
            billResponse.BranchId = billInformation?.BranchId;
            billResponse.BranchName = billInformation?.BranchName;
            billResponse.CreateDate = billInformation?.CreateDate;
            billResponse.TotalProductDetail = billDetails.Count;
            return billResponse;
        }

        public async Task<UpdateBillRequestDto> UpdateBill(UpdateBillRequestDto model)
        {
            if (model == null)
                return null;
            try
            {
                var existingBill = _context.Bills.SingleOrDefault(x => x.BillId == model.BillId);

                if (existingBill == null)
                    return null;

                existingBill.totalChange = model.totalChange;
                existingBill.totalPaid = model.totalPaid;
                existingBill.totalChange = model.totalChange;
                existingBill.CustomerId = model.CustomerId;
                existingBill.ModifyBy = model.UserId;
                existingBill.ModifyDate = DateTime.Now;

                // Update Bill Details
                foreach (var item in model.BillDetail)
                {
                    var billDetail = _context.BillDetails.SingleOrDefault(x => x.Id == item.Id);
                    if (billDetail != null)
                    {
                        billDetail.ProductId = item.ProductId;

                        billDetail.UnitId = item.UnitId;
                        billDetail.DiscountAmount = item.DiscountAmount;
                        billDetail.DiscountByPercentage = item.DiscountByPercentage;
                        billDetail.DiscountByPercentage = item.DiscountByPercentage;
                        billDetail.Quantity = item.Quantity;
                        billDetail.Amount = item.Amount;
                        billDetail.ModifyBy = model.UserId;
                        billDetail.ModifyDate = DateTime.Now;
                    }
                }

                // Update Bill Payment Methods
                foreach (var item in model.PaymentMethods)
                {
                    var billPayment = _context.BillPayments.SingleOrDefault(x => x.Id == item.Id);
                    if (billPayment != null)
                    {
                        var paymentMethodId = GetPaymentMethod(item.PaymentMethodCode);

                        billPayment.PaymentMethodId = paymentMethodId.Value;
                        billPayment.Amount = item.Amount;
                        billPayment.PaymentTransactionRef = item.PaymentTransactionRef;
                        billPayment.ModifyBy = model.UserId;
                        billPayment.ModifyDate = DateTime.Now;
                    }
                }

                _context.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBills(int billId)
        {
            try
            {
                var billPayments = _context.BillPayments
                .Where(x => x.BillId == billId).ToList();

                if (billPayments.Count > 0)
                {
                    _context.BillPayments.RemoveRange(billPayments);
                }

                var billDetail = _context.BillDetails
                    .AsNoTracking()
                    .Where(x => x.BillId == billId).ToList();

                if (billDetail.Count > 0)
                {
                    _context.BillDetails.RemoveRange(billDetail);
                }

                var bill = _context.Bills
                    .AsNoTracking()
                    .SingleOrDefault(x => x.BillId == billId);

                if (bill != null)
                {
                    _context.Bills.Remove(bill);
                }

                _context.SaveChanges();



                return true;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function DeleteBills: " + ex.Message, _path);
                return false;
            }
        }

        public async Task<ResponseDto> ExportBillDetailExcel(SearchCriteria model)
        {
            try
            {
                string fromDate = model.Criterias["FromDate"].ToString();
                string toDate = model.Criterias["ToDate"].ToString();

                string query = string.Format(@"
                    DROP TABLE IF EXISTS #tmp_bills
                    DROP TABLE IF EXISTS #tmp_detail
                    SELECT *
                    INTO #tmp_bills
                    FROM bills
                    WHERE CreateDate between CONVERT(datetime, '{0}') AND CONVERT(datetime, '{1}')

                    DROP TABLE IF EXISTS #tmp_detail
                    select b.BillId
		                    ,coalesce(d.CustomerCode, N'KL') As CustomerCode
		                    ,coalesce(d.CustomerName, N'Khách lẻ') As CustomerName
		                    ,c.ProductName AS ProductName
		                    ,DiscountAmount + b.Amount AS AmountBeforeDiscount
		                    ,b.DiscountAmount AS DiscountAmount
		                    ,b.Amount AS Amount
		                    ,a.CreateDate
                    INTO #tmp_detail
                    FROM #tmp_bills A
                    JOIN BillDetails b ON a.BillId = b.BillId
                    JOIN Products c on c.ProductId = b.ProductId
                    LEFT JOIN Customers d on d.CustomerId = A.CustomerId

                    SELECT CreateDate
		                    ,BillId
		                    ,CustomerCode
		                    ,CustomerName
		                    ,SUM(AmountBeforeDiscount) AS TotalAmountBeforeDiscount
		                    ,SUM(DiscountAmount) AS TotalDiscountAmount
		                    ,SUM(Amount) AS TotalAmount

                    FROM #tmp_detail
                    GROUP BY BillId
		                    ,CustomerCode
		                    ,CustomerName
		                    ,CreateDate
                    ORDER BY CreateDate DESC

                ", fromDate, toDate);

                var result = _context.BillExportDetailDtos.FromSqlRaw(query).ToList();

                // Headers
                var headers = new[] { "Ngày bán", "BillId", "Mã khách hàng", "Tên khách hàng", "Tổng tiền trước khi chiết khấu", "Tổng tiền chiết khấu", "Tổng tiền sau chiết khấu"};

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(StorageContant.billFilePathFomat, dateFormat, string.Format("BillDetail_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

                // Get the directory path
                string directoryPath = Path.GetDirectoryName(filePath);

                // Check if the directory exists, and if not, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(result, headers, filePath);

                _responseDto.Result = filePath;

            }
            catch (Exception ex)
            {

                var logger = new LogWriter("Function ExportBillDetailExcel: " + ex.Message, _path);
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }
        #region Handle Get Data
        private async Task<List<BillDetailResponseDto>> GetBillDetailHandler(int billId)
        {
            string query = string.Format(@"
                SELECT b.Id
		                ,b.DiscountAmount
		                ,b.DiscountByPercentage
		                ,b.DiscountPercentage
		                ,b.Quantity
		                ,b.Amount
		                ,p.ProductId
		                ,p.ProductName
                        ,p.ProductCode
		                ,u.UnitId
		                ,u.UnitName
		                ,b.BillId
                FROM dbo.BillDetails b
                JOIN dbo.Products p ON b.ProductId = p.ProductId
                JOIN dbo.Unit u ON b.UnitId = u.UnitId
                WHERE b.BillId = {0}
            ", billId);

            try
            {
                var result = _context.BillDetailResponseDtos.FromSqlRaw(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<List<BillPaymentDetailResponseDto>> GetBillPaymentMethods(int billId)
        {
            string query = string.Format(@"
 	                SELECT b.Id
			                ,b.Amount
			                ,b.PaymentTransactionRef
			                ,p.PaymentMethodCode
			                ,P.PaymentMethodName
	                FROM dbo.BillPayments b
	                JOIN dbo.PaymentMethods p ON b.PaymentMethodId = p.PaymentMethodId
	                WHERE b.BillId = {0}
            ", billId);

            try
            {
                var result = _context.BillPaymentDetailResponseDtos.FromSqlRaw(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private int? GetPaymentMethod(string paymentMethodCode)
        {
            string query = string.Format(@"
                SELECT PaymentMethodId
		                ,PaymentMethodCode
		                ,PaymentMethodName
                FROM dbo.PaymentMethods p
                WHERE p.PaymentMethodCode = '{0}'"
            , paymentMethodCode);

            var result = _context.PaymentMethodDtos
                        .FromSqlRaw(query)
                        .AsEnumerable()
                        .FirstOrDefault()?.PaymentMethodId;

            return result;
        }

        private List<EmployeeShiftInformationDto> GetEmployeeShifts()
        {
            string query = @"
                SELECT ShiftId
		                ,ShiftName
		                ,StartHour AS StartTime
		                ,EndHour AS EndTime
                FROM AccountsDb.dbo.EmployeeShifts
            ";

            try
            {
                var result = _context.EmployeeShiftInformationDtos.FromSqlRaw(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null; ;
            }
        }

        private BillSearchingResponseDto GetBillById(int billId)
        {
            string query = string.Format(@"
                            SELECT b.BillId
		                            ,b.totalAmount
		                            ,b.totalPaid
		                            ,b.totalChange
		                            ,b.CustomerId
		                            ,b.CreateBy AS UserId
		                            ,CONCAT(u.FirstName, ' ', u.LastName) AS UserName
		                            ,es.ShiftId AS ShiftId
		                            ,es.ShiftName AS ShiftName
		                            ,br.BranchId AS BranchId
		                            ,br.BranchName AS BranchName
		                            ,b.CreateDate AS CreateDate
		                            , CASE
			                            WHEN COALESCE(c.CustomerName, '') = '' THEN N'Khách Lẻ'
			                            ELSE c.CustomerName
		                            END AS CustomerName
                                    , c.CustomerCode
                            FROM dbo.Bills b
                            LEFT JOIN dbo.Customers c ON b.CustomerId = c.CustomerId
                            LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = b.ShiftId
                            LEFT JOIN AccountsDb.dbo.UserBranchs ub ON b.CreateBy = ub.UserId
                            LEFT JOIN dbo.Branches br ON br.BranchId = ub.BranchId
                            LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = b.CreateBy
                            WHERE b.BillId = {0}
            ", billId);

            try
            {
                var result = _context.billSearchingResponseDtos.FromSqlRaw(query).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
