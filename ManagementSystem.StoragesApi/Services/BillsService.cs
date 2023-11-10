using ManagementSystem.Common;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace ManagementSystem.StoragesApi.Services
{
    public class BillsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _context;
        private IConfiguration _configuration;
        private readonly string _path = string.Empty;

        public BillsService(StoragesDbContext context, IConfiguration configuration)
        {
            _unitOfWork = new UnitOfWork(context);
            _configuration = configuration;
            _context = context;

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
                    string[] includes = { "Storage" };
                    var quantityInStorage = _unitOfWork.ProductStorageRepository.GetWithInclude(x => x.ProductId == detail.ProductId, includes).Where(x => x.Storage.BranchId == (bill.BranchId ?? 1)).First();
                    if(quantityInStorage != null)
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

                var result = new TPagination<BillSearchingResponseDto>();
                result.Items = pagedData;
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
            ;
            billResponse.BillId = billId;
            billResponse.totalChange = billInformation.totalChange;
            billResponse.totalPaid = billResponse.totalPaid;
            billResponse.totalAmount = billInformation.totalAmount;
            billResponse.CustomerId = billInformation?.CustomerId;
            billResponse.CustomerName = billInformation?.CustomerName;
            billResponse.TotalBillAmount = billPayments.Sum(x => x.Amount.Value);
            billResponse.Details = billDetails;
            billResponse.Payments = billPayments;

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
									,NULL AS UserId
									,NULL AS UserName
									,NULL AS ShiftId
									,NULL AS ShiftName
									,NULL AS BranchId
									,NULL AS BranchName
									,NULL AS CreateDate
									, CASE
										WHEN COALESCE(c.CustomerName, '') = '' THEN N'Khách Lẻ'
										ELSE c.CustomerName
									END AS CustomerName
							FROM dbo.Bills b
							LEFT JOIN dbo.Customers c ON b.CustomerId = c.CustomerId
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
