using Dapper;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Functions;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using ManagementSystem.StoragesApi.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ManagementSystem.Common.Models.Dtos.Bills;
using ManagementSystem.Common.Helpers;

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
                var originPayment = _context.BillPayments.Where(x => x.BillId == model.BillId).AsNoTracking().Include(x => x.PaymentMethod).ToList();

                if (existingBill == null)
                    return null;

                // Update Customer Bills
                UpdateCustomerBill(model, existingBill);

                // Update with another customer
                existingBill.totalChange = model.totalChange;
                existingBill.totalPaid = model.totalPaid;
                existingBill.totalChange = model.totalChange;
                existingBill.CustomerId = model.CustomerId;
                existingBill.ModifyBy = model.UserId;
                existingBill.ModifyDate = DateTime.Now;
                existingBill.ShiftId = model.ShiftId;

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
                await UpdateBillPayment(model);

                _unitOfWork.Save();
                return model;
            }

            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> DeleteBills(int billId, int ActionUser)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"EXEC usp_delete_bill @BillId=${billId}, @UserId={ActionUser}");

                await DeleteAccountingVouchers(billId, ActionUser);

                return true;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function DeleteBills: " + ex.Message, _path);
                return false;
            }
        }

        public async Task<List<DiscountInformationDto>> ViewDiscountInformation(SearchCriteria model)
        {
            try
            {
                var result = await GetDiscountInformations(model);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ResponseDto> ExportDiscountInformationExcel(SearchCriteria model)
        {
            try
            {

                // Headers
                var headers = new[] { " Mã Chi Nhánh", "Chi Nhánh", "Ngày bán", "BillId", "Mã khách hàng", "Tên khách hàng", "Tổng tiền trước khi chiết khấu", "Tổng tiền chiết khấu", "Tổng tiền sau chiết khấu" };

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(StorageContant.billFilePathFomat, dateFormat, string.Format("ChietKhau_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

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

                var resul = await GetDiscountInformations(model);
                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(resul, headers, filePath);

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

        public async Task<List<BillRevenueInformationDto>> ViewRevenueInformation(SearchCriteria model)
        {
            try
            {
                var result = await GetRevenueInformations(model);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ResponseDto> ExportRevenueExcel(SearchCriteria model)
        {
            try
            {

                // Headers
                var headers = new[] { " Mã Chi Nhánh", "Chi Nhánh", "Ngày ghi sổ", "TK Nợ", "TK Có", "Loại Phiếu", "Số CT", "Số hóa đơn", "Mã Đối Tượng", "Tên Đối Tượng", "Giá Trị", "Nội Dung" };

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(StorageContant.billFilePathFomat, dateFormat, string.Format("DoanhThu_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

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

                var resul = await GetRevenueInformations(model);
                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(resul, headers, filePath);

                _responseDto.Result = filePath;

            }
            catch (Exception ex)
            {

                var logger = new LogWriter("Function ExportRevenueExcel: " + ex.Message, _path);
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        public async Task<ResponseDto> ExportBillDetailExcel(string listBillId)
        {
            try
            {

                // Headers
                var headers = new[] { "Hóa Đơn", "Mã Sản Phẩm", "Tên Sản Phẩm", "Số Lượng", "Thành Tiền" };

                // Handle file path
                string dateFormat = DateTime.Now.ToString("yyyyMMdd");
                string filePath = string.Format(StorageContant.billFilePathFomat, dateFormat, string.Format("chitiet_{0}_{1}.xlsx", dateFormat, DateTime.Now.Ticks));

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

                var resul = await GetBillExcelView(listBillId);
                // Call the generic function
                var excelExporter = new ExcelExporter();
                excelExporter.ExportToExcel(resul, headers, filePath);

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
            paymentMethodCode = paymentMethodCode == "BANKKING" ? "BANKING" : paymentMethodCode;
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
            string query = string.Format(@"
                SELECT ShiftId
		                ,ShiftName
		                ,StartHour AS StartTime
		                ,EndHour AS EndTime
                FROM {0}.dbo.EmployeeShifts
            ", SD.AccountDbName);

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
                            LEFT JOIN {0}.dbo.EmployeeShifts es ON es.ShiftId = b.ShiftId
                            LEFT JOIN {0}.dbo.UserBranchs ub ON b.CreateBy = ub.UserId
                            LEFT JOIN dbo.Branches br ON br.BranchId = ub.BranchId
                            LEFT JOIN {0}.dbo.Users u ON u.UserId = b.CreateBy
                            WHERE b.BillId = {1}
            ", SD.AccountDbName, billId);

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
        private async Task<ReceiptVoucher> GetReceiptVoucherByBillId(int billId)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);

            string query = @"SELECT *
                            FROM ReceiptVouchers
                            WHERE BillId = @billId";

            using (var connection = new SqlConnection(accountingConnection))
            {
                var receiptVoucher = await connection.QuerySingleOrDefaultAsync<ReceiptVoucher>(query, new { billId });

                return receiptVoucher;
            }
        }

        private async Task<CreditVoucher> GetCreditVoucher(int billId, int paymentMethodId)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);
            string query = @"SELECT *
                                FROM CreditVouchers
                                WHERE PaymentMethodId = @paymentMethodId AND BillId = @billId";

            using (var connection = new SqlConnection(accountingConnection))
            {
                var creditVoucher = await connection.QuerySingleOrDefaultAsync<CreditVoucher>(query, new { paymentMethodId, billId });

                return creditVoucher;
            }
        }

        private async Task<InventoryVoucher> GetInventoryVoucher(int billId)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);
            string query = @"SELECT *
                                FROM InventoryVouchers
                                WHERE BillId = @billId";

            using (var connection = new SqlConnection(accountingConnection))
            {
                var inventoryVoucher = await connection.QuerySingleOrDefaultAsync<InventoryVoucher>(query, new { billId });

                return inventoryVoucher;
            }
        }

        private async Task<List<BillDetailExcelView>> GetBillExcelView(string listBills)
        {
            string connectionString = _configuration.GetConnectionString("StoragesDbConnStr");

            string query = string.Format(@"SELECT b.ProductCode
                                            ,a.BillId
		                                    ,b.ProductName
		                                    ,a.Quantity
		                                    ,a.Amount
                                    FROM BillDetails a
                                    JOIN Products B ON a.ProductId = b.ProductId
                                    WHERE a.BillId IN ({0})

                                    ORDER BY a.BillId", listBills);
            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query<BillDetailExcelView>(query).ToList();

                return result;
            }
        }
        private async Task DeleteVoucher(int documentNumber, string query, string documentType)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);

            string legerDeleteQuery = @"DELETE Legers WHERE DoccumentNumber = @documentNumber AND DoccumentType = @documentType";

            using (var connection = new SqlConnection(accountingConnection))
            {
                await connection.ExecuteAsync(legerDeleteQuery, new { documentNumber, documentType });
                await connection.ExecuteAsync(query, new { documentNumber });

            }
        }

        private async Task UpdateVoucherAmount(int documentNumber, float amount, string query, string documentType)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);

            string updateLegerQuery = @"UPDATE Legers
                                        SET Amount = @amount
                                        WHERE DoccumentNumber = @documentNumber
                                        AND DoccumentType = @documentType";

            using (var connection = new SqlConnection(accountingConnection))
            {
                await connection.ExecuteAsync(updateLegerQuery, new { amount, documentNumber, documentType });
                await connection.ExecuteAsync(query, new { amount, documentNumber });

            }
        }
        private async Task<List<DiscountInformationDto>> GetDiscountInformations(SearchCriteria model)
        {
            string fromDate = model.Criterias["fromDate"].ToString();
            string toDate = model.Criterias["toDate"].ToString();

            string query = string.Format(@"
                    DROP TABLE IF EXISTS #tmp_bills
                    DROP TABLE IF EXISTS #tmp_detail
                    SELECT *
                    INTO #tmp_bills
                    FROM bills
                    WHERE FORMAT(CreateDate, 'yyyy-MM-dd') between CONVERT(datetime, '{0}') AND CONVERT(datetime, '{1}')

                    DROP TABLE IF EXISTS #tmp_detail
                    select b.BillId
		                    ,coalesce(d.CustomerCode, N'KL') As CustomerCode
		                    ,coalesce(d.CustomerName, N'Khách lẻ') As CustomerName
		                    ,c.ProductName AS ProductName
		                    ,DiscountAmount + b.Amount AS AmountBeforeDiscount
		                    ,b.DiscountAmount AS DiscountAmount
		                    ,b.Amount AS Amount
		                    ,a.CreateDate
							,e.BranchCode
							,e.BranchName
                    INTO #tmp_detail
                    FROM #tmp_bills A
                    JOIN BillDetails b ON a.BillId = b.BillId
                    JOIN Products c on c.ProductId = b.ProductId
					JOIN Branches e ON e.BranchId = a.BranchId
                    LEFT JOIN Customers d on d.CustomerId = A.CustomerId

                    SELECT CreateDate
		                    ,BillId
							,BranchCode
							,BranchName
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
							,BranchCode
							,BranchName
                    ORDER BY CreateDate DESC

                ", fromDate, toDate);

            var result = _context.DiscountInformationDtos.FromSqlRaw(query).ToList();

            return result;
        }
        private async Task<List<BillRevenueInformationDto>> GetRevenueInformations(SearchCriteria model)
        {
            string fromDate = model.Criterias["fromDate"].ToString();
            string toDate = model.Criterias["toDate"].ToString();

            string query = string.Format(@"
                WITH cte as
                (
                SELECT DISTINCT IIF (COALESCE(br.BranchCode, '') <> '', br.BranchCode, h.BranchCode) AS BranchCode
		                ,IIF (COALESCE(br.BranchName, '') <> '', br.BranchName, h.BranchName) AS BranchName
		                ,FORMAT(a.TransactionDate, 'yyyy-MM-dd HH:MM:ss') AS TransactionDate
		                ,a.DepositAccount
		                ,a.CreditAccount
		                ,a.DoccumentType
		                ,a.DoccumentNumber
		                ,a.BillId
		                ,COALESCE(d.CustomerCode, 'KL') AS CustomerCode
		                ,COALESCE(d.CustomerName, N'Khách lẻ') AS CustomerName
		                ,a.Amount
		                ,COALESCE(b.ForReason, c.ForReason) ForReason
                FROM {0}..Legers a
                LEFT JOIN StoragesProdDb.dbo.Customers d on d.CustomerId = a.CustomerId
                LEFT JOIN {0}.[dbo].[ReceiptVouchers] b on b.DocumentNumber = a.DoccumentNumber and a.DoccumentType = 'THU'
                LEFT JOIN {0}.[dbo].[CreditVouchers] c on c.DocumentNumber = a.DoccumentNumber and a.DoccumentType = 'BAOCO'
                LEFT JOIN StoragesProdDb.dbo.Bills e on e.BillId = a.BillId
                LEFT JOIN StoragesProdDb.dbo.Branches br on br.BranchId = e.BranchId
                LEFT JOIN {1}..UserBranchs g on g.UserId = a.UserId
                LEFT JOIN StoragesProdDb..Branches h ON g.BranchId = h.BranchId
                where DoccumentType <> 'Chi'
                AND 
                (FORMAT(a.TransactionDate, 'yyyy-MM-dd') between CONVERT(datetime, '{2}') AND CONVERT(datetime, '{3}')))

                SELECT *
                from cte
                ORDER BY BranchCode, TransactionDate
            ", SD.AccountingDbName, SD.AccountDbName, fromDate, toDate);

            var result = _context.BillRevenueInformationDtos.FromSqlRaw(query).ToList();

            return result;
        }

        private async Task DeleteAccountingVouchers(int billId, int actionUser)
        {
            string accountingConnection = string.Format(_configuration.GetConnectionString("AcountingsDbConnStr"), SD.AccountingDbName);

            string deleterQuery = @"usp_delete_bill_handling";

            var parameters = new DynamicParameters();
            parameters.Add("@BillId", billId);
            parameters.Add("@UserId", actionUser);
            using (var connection = new SqlConnection(accountingConnection))
            {
                await connection.ExecuteAsync(deleterQuery, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        private void UpdateCustomerBill(UpdateBillRequestDto model, Bill existingBill)
        {
            try
            {
                var billCustomer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == existingBill.CustomerId);
                var newCustomer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == model.CustomerId);

                // Update KL to customer
                if (billCustomer == null && newCustomer != null)
                {
                    newCustomer.CustomerPoint += model.totalAmount / StorageContant.ConventPoint;
                }
                // Update customer from KL
                else if (billCustomer != null && newCustomer == null)
                {
                    billCustomer.CustomerPoint -= model.totalAmount / StorageContant.ConventPoint;
                }
                else if (billCustomer != null && newCustomer != null && billCustomer.CustomerId != newCustomer.CustomerId)
                {
                    billCustomer.CustomerPoint -= model.totalAmount / StorageContant.ConventPoint;
                    newCustomer.CustomerPoint += model.totalAmount / StorageContant.ConventPoint;
                }
                else if (billCustomer != null && existingBill.totalAmount != model.totalAmount)
                {
                    billCustomer.CustomerPoint += (existingBill.totalAmount > model.totalAmount
                            ? model.totalAmount - existingBill.totalAmount
                            : existingBill.totalAmount - model.totalAmount) / StorageContant.ConventPoint;
                }

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateBillPayment(UpdateBillRequestDto model)
        {
            try
            {
                foreach (var item in model.PaymentMethods)
                {
                    var billPayment = _context.BillPayments.Include(x => x.PaymentMethod).SingleOrDefault(x => x.Id == item.Id);
                    var inventoryVoucher = await GetInventoryVoucher(model.BillId);
                    var paymentMethodId = GetPaymentMethod(item.PaymentMethodCode);


                    if (billPayment != null)
                    {
                        // Update bill payments
                        int oldPaymentMethod = billPayment.PaymentMethodId;
                        billPayment.PaymentMethodId = paymentMethodId.Value;
                        billPayment.Amount = item.Amount;
                        billPayment.PaymentTransactionRef = item.PaymentTransactionRef;
                        billPayment.ModifyBy = model.UserId;
                        billPayment.ModifyDate = DateTime.Now;

                        // Update credit and recipt voucher
                        if (billPayment.PaymentMethod.PaymentMethodCode != item.PaymentMethodCode)
                        {
                            await UpdateChangePaymentMethodWithVoucher(model, item, inventoryVoucher, oldPaymentMethod, paymentMethodId.Value);
                        }
                        else
                        {
                            await UpdateChangeAmountWithVoucher(item, model.BillId, paymentMethodId.Value);
                        }
                    }
                    // New Payment method
                    else
                    {
                        UpdateAddNewPaymentMethod(model, item, inventoryVoucher, model.BillId, paymentMethodId.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateChangePaymentMethodWithVoucher(UpdateBillRequestDto model, UpdateBillPaymentMethodRequestDto updatedBill, InventoryVoucher inventoryVoucher, int oldPaymentMethodId, int newPaymentMethod)
        {
            try
            {
                var creditVoucher = await GetCreditVoucher(model.BillId, oldPaymentMethodId);
                var receiptVoucher = await GetReceiptVoucherByBillId(model.BillId);

                if (updatedBill.PaymentMethodCode == StorageContant.CashPaymentMethodCode)
                {
                    // Delete voucher
                    if (creditVoucher != null)
                    {
                        string deletedCredit = "DELETE CreditVouchers WHERE DocumentNumber = @documentNumber";
                        await DeleteVoucher(creditVoucher.DocumentNumber, deletedCredit, "BAOCO");
                    }

                    // Add receipt

                    var newReceiptDto = new NewReceiptRequestDto()
                    {
                        CustomerId = model.CustomerId,
                        ForReason = string.Format(AccountingConstant.ReceiptReason, inventoryVoucher.DocummentNumber),
                        UserId = model.UserId.Value,
                        TotalMoney = updatedBill.Amount,
                        BillId = model.BillId,
                        StorageId = 0,
                        InventoryDocumentNumber = inventoryVoucher.DocummentNumber
                    };

                    await HttpRequestsHelper.Post<CreditVoucher>(SD.AccountingApiUrl + "Receipt/create", newReceiptDto);
                }
                else
                {
                    if (creditVoucher == null)
                    {
                        // Delete recepit
                        if (receiptVoucher != null)
                        {
                            string deletedReceipt = "DELETE ReceiptVouchers WHERE DocumentNumber = @documentNumber";
                            await DeleteVoucher(receiptVoucher.DocumentNumber, deletedReceipt, "THU");
                        }

                        // Add Credit Voucher

                        var newCreditVoucher = new NewCreditVoucherRequestDto()
                        {
                            CustomerId = model.CustomerId,
                            TotalMoney = updatedBill.Amount,
                            UserId = model.UserId.Value,
                            BillId = model.BillId,
                            BrandId = model.BranchId != null ? model.BranchId : 0,
                            PaymentMethodCode = updatedBill.PaymentMethodCode == "BANKKING" ? "BANKING" : updatedBill.PaymentMethodCode,
                            ProductId = model.BillDetail[0].ProductId,
                            GroupId = AccountingConstant.AutoGenerateDocumentGroup
                        };

                        await HttpRequestsHelper.Post<CreditVoucher>(SD.AccountingApiUrl + "CreditVouchers/create", newCreditVoucher);
                    }
                    else
                    {
                        string query = string.Format(@"
                                        UPDATE CreditVouchers
                                        SET TotalMoney = @amount
                                            ,PaymentMethodId = {0}
                                        WHERE DocumentNumber = @documentNUmber", newPaymentMethod)
                        ;

                        await UpdateVoucherAmount(creditVoucher.DocumentNumber, updatedBill.Amount, query, "BAOCO");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateChangeAmountWithVoucher(UpdateBillPaymentMethodRequestDto updatedBill, int billId, int paymentMethodId)
        {
            try
            {
                string query = string.Empty;
                var creditVoucher = await GetCreditVoucher(billId, paymentMethodId);
                var receiptVoucher = await GetReceiptVoucherByBillId(billId);
                if (updatedBill.Amount != receiptVoucher?.TotalMoney || updatedBill.Amount != creditVoucher?.TotalMoney)
                {
                    if (updatedBill.PaymentMethodCode == StorageContant.CashPaymentMethodCode)
                    {
                        query = @"
                            UPDATE ReceiptVouchers
                            SET TotalMoney = @amount
                            WHERE DocumentNumber = @documentNUmber";

                        await UpdateVoucherAmount(receiptVoucher.DocumentNumber, updatedBill.Amount, query, "THU");
                    }
                    else
                    {
                        query = @"
                            UPDATE CreditVouchers
                            SET TotalMoney = @amount
                            WHERE DocumentNumber = @documentNUmber";

                        await UpdateVoucherAmount(creditVoucher.DocumentNumber, updatedBill.Amount, query, "BAOCO");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task UpdateAddNewPaymentMethod(UpdateBillRequestDto model, UpdateBillPaymentMethodRequestDto updatedBill, InventoryVoucher inventoryVoucher, int billId, int paymentMethodId)
        {
            // Add billPayment
            _context.BillPayments.Add(new BillPayment()
            {
                BillId = billId,
                Amount = updatedBill.Amount,
                PaymentMethodId = paymentMethodId,
            });

            // truong hop them 1 method moi
            if (updatedBill.PaymentMethodCode == StorageContant.CashPaymentMethodCode)
            {
                // Add receipt

                var newReceiptDto = new NewReceiptRequestDto()
                {
                    CustomerId = model.CustomerId,
                    ForReason = string.Format(AccountingConstant.ReceiptReason, inventoryVoucher.DocummentNumber),
                    UserId = model.UserId.Value,
                    TotalMoney = updatedBill.Amount,
                    BillId = model.BillId,
                    StorageId = 0,
                    InventoryDocumentNumber = inventoryVoucher.DocummentNumber
                };

                await HttpRequestsHelper.Post<CreditVoucher>(SD.AccountingApiUrl + "Receipt/create", newReceiptDto);
            }
            else
            {
                // Add Credit Voucher

                var newCreditVoucher = new NewCreditVoucherRequestDto()
                {
                    CustomerId = model.CustomerId,
                    TotalMoney = updatedBill.Amount,
                    UserId = model.UserId.Value,
                    BillId = model.BillId,
                    BrandId = model.BranchId != null ? model.BranchId : 0,
                    PaymentMethodCode = updatedBill.PaymentMethodCode == "BANKKING" ? "BANKING" : updatedBill.PaymentMethodCode,
                    ProductId = model.BillDetail[0].ProductId,
                    GroupId = AccountingConstant.AutoGenerateDocumentGroup
                };

                await HttpRequestsHelper.Post<CreditVoucher>(SD.AccountingApiUrl + "CreditVouchers/create", newCreditVoucher);
            }

            if (updatedBill.PaymentMethodCode == StorageContant.PointPaymentMethod)
            {
                var customer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == model.CustomerId);
                if (customer != null)
                {
                    customer.CustomerPoint -= (int)updatedBill.Amount / StorageContant.ConventPoint;
                }
            }
        }

        #endregion
    }
}
