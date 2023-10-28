using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Loggers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.AccountingApi.Services
{
    public class EmployeeShiftReportService : IEmployeeShiftReportService
    {
        private readonly AccountingDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _path = string.Empty;

        public EmployeeShiftReportService(AccountingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _path = @"C:\\Logs\\EmployeeShift";
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
                var logger = new LogWriter("Function CreateShiftEndReport: " + ex.Message, _path);

                return null;
            }
        }

        public async Task<TPagination<ShiftHandoverResponseDto>> GetAllShiftHandover(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);

                // Your DbContextFactory and DbContext creation code
                var dbContextFactory = new DbContextFactory(_configuration);
                using var dbContext = dbContextFactory.CreateDbContext<AccountingDbContext>("AcountingsDbConnStr");

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@xmlString", xmlString )
                };

                int pageNumber = criteria.PageNumber <= 0 ? 1 : criteria.PageNumber;
                int pageSize = criteria.PageSize <= 0 ? 10 : criteria.PageSize;

                var executeResult = await GenericSearchRepository<ShiftHandoverResponseDto>.ExecutePagedStoredProcedureCommonAsync<ShiftHandoverResponseDto>
                                                                                    (dbContext, "sp_shift_handovers", pageNumber, pageSize, parameters);

                // Process the results
                List<ShiftHandoverResponseDto> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var result = new TPagination<ShiftHandoverResponseDto>();
                result.Items = pagedData;
                result.TotalItems = totalRecords;
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
                var logger = new LogWriter("Function GetShiftReport: " + ex.Message, _path);
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
                      LEFT JOIN dbo.ShiftHandoverCashDetails sD ON sd.ShiftEndId = sr.ShiftEndId
                      LEFT JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
                      WHERE sh.HandoverId = {0}
                      GROUP BY sr.ShiftEndId
                  ),
                  preData
                  AS
                  (
	                SELECT *, 6 AS KeyJoin
	                FROM dbo.ShiftReports 
	                WHERE  HandoverId = 
		                (
			                SELECT MAX(HandoverId)
			                FROM dbo.ShiftHandovers
			                WHERE HandoverId < {0}
		                )
                  ),
                  cte_users
                  AS
                  (
		                SELECT *
		                FROM AccountsDb.dbo.Users
                  )

                  SELECT sh.HandoverId
                          ,es.ShiftId
                          ,sr.ShiftEndId
                          ,es.ShiftName
                          ,sh.HandoverTime AS HandoverDate
                          ,COALESCE(t.TotalBill, 0) AS TotalAmount
                          ,s.TotalShiftInMoney AS CurShiftAmount
                          ,COALESCE(pre.TotalShiftInMoney, 0) AS PreShiftAmount
		                  ,sender1.UserId AS SenderId1
		                  ,sender1.UserName AS SenderName1
		                  ,sender2.UserId AS SenderId2
		                  ,sender2.UserName AS SenderUser2
		                  ,receiver.UserId AS ReceiverId
		                  ,receiver.UserName AS ReceiverName
		                  ,sto.StorageId
		                  ,sto.StorageName
		                  ,sh.Note
		                  ,sh.Status
                  FROM cte t
                  JOIN dbo.ShiftEndReports sr ON sr.ShiftEndId = t.ShiftEndId
                  JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
                  JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
                  JOIN dbo.ShiftReports s ON s.HandoverId = sh.HandoverId
                  LEFT JOIN preData pre ON pre.KeyJoin = sh.HandoverId
                  JOIN cte_users sender1 ON sh.SenderUserId1 = sender1.UserId
                  LEFT JOIN cte_users sender2 ON sh.SenderUserI2 = sender2.UserId
                  LEFT JOIN cte_users receiver ON sh.ReceiverUserId = receiver.UserId
                  LEFT JOIN StoragesDb.DBO.Storages sto ON SH.StorageId = sto.StorageId
            ", handoverId);

            try
            {
                var result = _context.ShiftHandoverResponseDtos.FromSqlRaw(query).AsEnumerable().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter("Function GetShiftHandover: " + ex.Message, _path);

                return null;
            }
        }

        public async Task<TPagination<ShiftEndResponseDto>> SearchShiftEndReports(SearchCriteria criteria)
        {
            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(criteria);

                // Your DbContextFactory and DbContext creation code
                var dbContextFactory = new DbContextFactory(_configuration);
                using var dbContext = dbContextFactory.CreateDbContext<AccountingDbContext>("AcountingsDbConnStr");

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@xmlString", xmlString )
                };

                int pageNumber = criteria.PageNumber <= 0 ? 1 : criteria.PageNumber;
                int pageSize = criteria.PageSize <= 0 ? 10 : criteria.PageSize;

                var executeResult = await GenericSearchRepository<ShiftEndReportView>.ExecutePagedStoredProcedureCommonAsync<ShiftEndReportView>
                                                                                    (dbContext, "sp_SearchShiftEndReports", pageNumber, pageSize, parameters);

                // Process the results
                List<ShiftEndReportView> pagedData = executeResult.Item1;
                int totalRecords = executeResult.Item2;

                var mapResult = MapShiftEndReportViewToDto(pagedData).ToList();

                var result = new TPagination<ShiftEndResponseDto>();
                result.Items = mapResult;
                result.TotalItems = totalRecords;

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

        public async Task<ShiftEndResponseDto> GetShiftEndById(int shiftEndId)
        {
            string sqlQuery = string.Format(@"
                            SELECT s.ShiftEndId
								,s.UserId
								,u.UserName
								,es.ShiftId
								,es.ShiftName
								,s.ShiftEndDate
								,s.CompanyMoneyTransferred
								,sh.Denomination
								,sh.Amount
								,sa.ProductId
								,p.ProductName
								,ui.UnitId
								,ui.UnitName
								,COALESCE(sa.ActualAmount, 0) AS ActualAmount
								,COALESCE(sa.SystemAmount, 0) AS SystemAmount
								,b.BranchId
								,b.BranchName
						   FROM dbo.ShiftEndReports s
						   LEFT JOIN dbo.InventoryAuditDetails sa ON sa.ShiftEndId = s.ShiftEndId
						   LEFT JOIN dbo.ShiftHandoverCashDetails sh ON sh.ShiftEndId = s.ShiftEndId
						   LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = s.UserId
						   LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = s.ShiftId
						   LEFT JOIN StoragesDb.dbo.Products p ON p.ProductId = sa.ProductId
						   LEFT JOIN StoragesDb.dbo.Unit ui ON sa.UnitId = ui.UnitId
						   LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
						   LEFT JOIN StoragesDb.dbo.Branches b ON b.BranchId = ub.BranchId
                WHERE s.ShiftEndId = {0}
                ", shiftEndId);

            try
            {
                var data = GetShiftEndReportData(sqlQuery);
                var result = MapShiftEndReportViewToDto(data).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                var logger = new LogWriter(ex.Message, _path);
                return null;
            }
        }

        public async Task<bool> IsCompletedShiftEnd(int shiftId)
        {
            try
            {
                string query = string.Format(@"
                        SELECT COUNT(1) AS Value
                        FROM dbo.ShiftEndReports s
                        JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = s.ShiftEndId
                        WHERE FORMAT(ShiftEndDate, 'yyyy-MM-dd') = FORMAT(GETDATE(), 'yyyy-MM-dd')
                        AND COALESCE(sh.ReceiverUserId, '') <> ''
                        AND s.ShiftId = {0}", shiftId);

                int count = _context.CalculateScalarFunction<ScalarResult<int>>(query).Value;

                return count > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private function handle
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
                var result = _context.ShiftEndReportViews.FromSqlRaw(sqlQuery).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private IEnumerable<ShiftEndResponseDto> MapShiftEndReportViewToDto(IEnumerable<ShiftEndReportView> reportViews)
        {
            var groupByResult = reportViews.GroupBy(x => new { x.ShiftId, x.UserId, x.UserName, x.ShiftEndId, x.ShiftEndDate, x.CompanyMoneyTransferred, x.ShiftName, x.BranchId, x.BranchName }).ToList();

            var result = new List<ShiftEndResponseDto>();

            foreach (var item in groupByResult)
            {
                var detail = new ShiftEndResponseDto();

                detail.ShiftEndId = item.Key.ShiftEndId;
                detail.UserId = item.Key.UserId;
                detail.UserName = item.Key.UserName;
                detail.ShiftId = item.Key.ShiftId;
                detail.ShiftName = item.Key.ShiftName;
                detail.ShiftEndDate = item.Key.ShiftEndDate;
                detail.CompanyMoneyTransferred = item.Key.CompanyMoneyTransferred;
                detail.BranchId = item.Key.BranchId;
                detail.BranchName = item.Key.BranchName;

                var cashDetails = new List<CashDetailDto>();
                var inventoryDetails = new List<InventoryAuditDetailDto>();

                foreach (var detatilInfor in item.Select(x => new { x.Denomination, x.Amount }).Distinct())
                {
                    var cash = new CashDetailDto
                    {
                        Denomination = detatilInfor.Denomination,
                        Amount = detatilInfor.Amount
                    };



                    cashDetails.Add(cash);

                }

                foreach (var detatilInfor in item.Select(x => new { x.ProductId, x.ProductName, x.ActualAmount, x.SystemAmount, x.UnitId, x.UnitName }).Distinct())
                {
                    var inventory = new InventoryAuditDetailDto
                    {
                        ProductId = detatilInfor.ProductId,
                        ProductName = detatilInfor.ProductName,
                        ActualAmount = detatilInfor.ActualAmount,
                        SystemAmount = detatilInfor.SystemAmount,
                        UnitId = detatilInfor.UnitId,
                        UnitName = detatilInfor.UnitName
                    };
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
