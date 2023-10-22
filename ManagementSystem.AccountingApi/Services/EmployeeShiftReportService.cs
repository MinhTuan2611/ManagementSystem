using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class EmployeeShiftReportService : IEmployeeShiftReportService
    {
        private readonly AccountingDbContext _context;
        public EmployeeShiftReportService(AccountingDbContext context)
        {
            _context = context;
        }

        public ShiftEndReport CreateShiftEndReport(NewEmployeeShiftEndRequestDto model)
        {
            try
            {
                int storageId = 0;
                int shiftEndId = 0;
                var shiftEnd = new ShiftEndReport();
                var existingShift = IsExistsShiftEndReports(model.ShiftId.Value, DateTime.Now.ToString("yyyy-MM-dd"));

                if (existingShift <= 0)
                {

                    shiftEnd.CompanyMoneyTransferred = model.CompanyMoneyTransferred;
                    shiftEnd.UserId = model.UserId;
                    shiftEnd.ShiftId = model.ShiftId;

                    _context.ShiftEndReports.Add(shiftEnd);
                    _context.SaveChanges();

                    shiftEndId = shiftEnd.ShiftEndId;

                    foreach (var item in model.AuditDetails)
                    {
                        var auditDetail = new InventoryAuditDetail();
                        var storage = GetProductStorageDto(item.ProductId);

                        auditDetail.ShiftEndId = shiftEndId;
                        auditDetail.ProductId = item.ProductId;
                        auditDetail.UnitId = item.UnitId;
                        auditDetail.ActualAmount = item.ActualAmount;
                        auditDetail.SystemAmount = storage.Quantity.Value;
                        storageId = storage.StorageId.Value;

                        _context.InventoryAuditDetails.Add(auditDetail);
                    }

                    foreach (var item in model.ShiftHandoverCashDetails)
                    {
                        var cahsDetail = new ShiftHandoverCashDetail();
                        cahsDetail.ShiftEndId = shiftEndId;
                        cahsDetail.Denomination = item.Denomination;
                        cahsDetail.Amount = item.Amount;

                        _context.ShiftHandoverCashDetails.Add(cahsDetail);
                    }

                    var shiftResult = ExportShiftHandover(shiftEndId, storageId, model.BrandId.Value);

                    // Add activity logs
                    _context.ActivityLog.Add(new ActivityLog()
                    {
                        UserId = model.UserId.Value,
                        Action = "Add ShiftEndReport: " + shiftEndId.ToString(),
                        Source = "ShiftEndReport",
                        DateModified = DateTime.Now,
                    });
                    _context.SaveChanges();

                    return shiftEnd;
                }

                shiftEnd.ShiftId = existingShift;
                return shiftEnd;
            }
            catch (Exception ex)
            {
                var errorLogger = new ErrorLogger(GenerateFilePath());
                errorLogger.LogError("Function CreateShiftEndReport: " + ex.Message);

                return null;
            }
        }

        public async Task<List<ShiftHandoverResponseDto>> GetAllShiftHandover(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);
                var result = _context.ShiftHandoverResponseDtos.FromSqlRaw(string.Format("EXEC sp_shift_handovers '{0}', {1}, {2}", xmlString, criteria.PageNumber, criteria.PageSize)).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ShiftReportResponseDto> GetShiftReport(int shiftEndId)
        {
            string query = string.Format(@"
                    SELECT es.ShiftId
		                    ,es.ShiftName
		                    ,se.UserId
		                    ,u.UserName
		                    ,sr.TotalBill
		                    ,sr.TotalShiftInMoney
		                    ,sr.TotalRevenue
		                    ,sr.TotalCashAmount
		                    ,sr.TotalVoucherAmount
		                    ,sr.TotalCardAmount
		                    ,sr.TotalInternalConsumption
		                    ,sr.TotalMOMOAmount
		                    ,sr.TotalExpenses
		                    ,sr.OtherExpense
		                    ,sr.ActualMoneyForNextShift
		                    ,sr.RemindMoneyForNextShift
		                    ,sr.ExcessMoney
		                    ,sr.LackOfMoney
		                    ,se.ShiftEndDate
                    FROM dbo.ShiftEndReports se
                    JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = se.ShiftEndId
                    JOIN dbo.ShiftReports sr ON sr.HandoverId = sh.HandoverId
                    JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
                    JOIN AccountsDb.dbo.Users u ON u.UserId = se.UserId
                    WHERE se.ShiftEndId = {0}
                ", shiftEndId);

            try
            {
                var result = _context.ShiftReportResponseDtos.FromSqlRaw(query).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ShiftHandoverResponseDto> GetShiftHandover(int handoverId)
        {
            string query = string.Format(@"
                ;WITH cte
                AS
                (
	                SELECT sr.ShiftEndId
		                ,SUM(sd.Denomination * sd.Amount) AS TotalBill
	                FROM dbo.ShiftEndReports sr
	                JOIN dbo.ShiftHandoverCashDetails sD ON sd.ShiftEndId = sr.ShiftEndId
	                JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
	                WHERE sh.HandoverId = {0}
	                GROUP BY sr.ShiftEndId
                )

                SELECT sh.HandoverId
		                ,es.ShiftId
		                ,es.ShiftName
		                ,sh.HandoverTime AS HandoverDate
		                ,t.TotalBill AS TotalAmount
		                ,s.TotalShiftInMoney AS CurShiftAmount
		                ,LAG(s.TotalShiftInMoney) OVER (ORDER BY sr.ShiftEndId) AS PreShiftAmount
                FROM cte t
                JOIN dbo.ShiftEndReports sr ON sr.ShiftEndId = t.ShiftEndId
                JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
                JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
                JOIN dbo.ShiftReports s ON s.HandoverId = sh.HandoverId
            ", handoverId);

            try
            {
                var result = _context.ShiftHandoverResponseDtos.FromSqlRaw(query).AsEnumerable().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ShiftEndResponseDto>> SearchShiftEndReports(SearchCriteria criteria)
        {
            string xmlString = XMLCommonFunction.SerializeToXml(criteria);
            string sqlQuery = string.Format("EXEC dbo.sp_SearchShiftEndReports '{0}', {1}, {2}", xmlString, criteria.PageNumber, criteria.PageSize);

            try
            {
                var data = GetShiftEndReportData(sqlQuery);
                var result = MapShiftEndReportViewToDto(data).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ShiftEndResponseDto> GetLastestShiftEnd()
        {
            string sqlQuery = "SELECT * FROM dbo.ShiftEndReportView_latest";

            try
            {
                var data = GetShiftEndReportData(sqlQuery);
                var result = MapShiftEndReportViewToDto(data).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private function handle
        private string GenerateFilePath()
        {
            DateTime now = DateTime.Now;

            // Create the date and time components in the desired format
            string datePart = now.ToString("yyyyMMdd");
            string timePart = now.ToString("HHmmss");

            // Combine them into a single path
            string path = @$"C://logs/ShiftEndReport/{datePart}/{timePart}.txt";

            return path;
        }

        private ProductStorageInformationDto GetProductStorageDto(int productId)
        {
            string query = string.Format(@"
                SELECT s.StorageId
		                ,ps.ProductId
		                ,COALESCE(ps.Quantity, 0) AS Quantity
                FROM StoragesDb.dbo.Storages s
                LEFT JOIN StoragesDb.dbo.ProductStorages ps ON s.StorageId = ps.StorageId
                WHERE ps.ProductId = {0}
            ", productId);

            var productStorage = _context.ProductStorageInformationDtos.FromSqlRaw(query).FirstOrDefault();

            return productStorage;
        }


        private async Task<bool> ExportShiftHandover(int shiftEndId, int storageId, int brandId)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(string.Format("EXEC dbo.sp_generate_shift_handover {0}, {1}, {2}", shiftEndId, storageId, brandId));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int IsExistsShiftEndReports(int shiftId, string dateString)
        {
            try
            {
                string query = string.Format(@"
                    SELECT ShiftEndId AS Value
                    FROM dbo.ShiftEndReports
                    WHERE FORMAT(ShiftEndDate, 'yyyy-MM-dd') = '{0}'
                    AND ShiftId = {1}
                ", dateString, shiftId);

                var count = _context.CalculateScalarFunction<ScalarResult<int>>(query).Value; // Create a DbSet for a scalar type (int)

                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<ShiftEndReportView> GetShiftEndReportData(string sqlQuery)
        {
            try
            {
                return _context.ShiftEndReportViews.FromSqlRaw(sqlQuery).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private IEnumerable<ShiftEndResponseDto> MapShiftEndReportViewToDto(IEnumerable<ShiftEndReportView> reportViews)
        {
            var groupByResult = reportViews.GroupBy(x => new {x.ShiftId, x.UserId, x.UserName, x.ShiftEndId, x.ShiftEndDate,x.CompanyMoneyTransferred, x.ShiftName }).ToList();

            var result = new List<ShiftEndResponseDto>();

            foreach(var item in groupByResult)
            {
                var detail = new ShiftEndResponseDto();

                detail.ShiftEndId = item.Key.ShiftEndId;
                detail.UserId = item.Key.UserId;
                detail.UserName = item.Key.UserName;
                detail.ShiftId = item.Key.ShiftId;
                detail.ShiftName = item.Key.ShiftName;
                detail.ShiftEndDate = item.Key.ShiftEndDate;
                detail.CompanyMoneyTransferred = item.Key.CompanyMoneyTransferred;

                var cashDetails = new List<CashDetailDto>();
                var inventoryDetails = new List<InventoryAuditDetailDto>();

                foreach(var detatilInfor in item)
                {
                    var cash = new CashDetailDto
                    {
                        Denomination = detatilInfor.Denomination,
                        Amount = detatilInfor.Amount
                    };

                    var inventory = new InventoryAuditDetailDto
                    {
                        ProductId = detatilInfor.ProductId,
                        ProductName = detatilInfor.ProductName,
                        ActualAmount = detatilInfor.ActualAmount,
                        SystemAmount = detatilInfor.SystemAmount,
                        UnitId = detatilInfor.UnitId,
                        UnitName = detatilInfor.UnitName
                    };

                    cashDetails.Add(cash);
                    inventoryDetails.Add(inventory);
                }

                detail.CashDetails = cashDetails;
                detail.InventoryAuditDetails = inventoryDetails;

                result.Add(detail);
            }

            return result;
        }
        #endregion
    }
}
