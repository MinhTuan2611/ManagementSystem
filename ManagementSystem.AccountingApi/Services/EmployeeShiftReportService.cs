using ManagementSystem.AccountingApi.Data;
using ManagementSystem.Common.Entities;
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

        public async Task<ShiftEndReport> CreateShiftEndReport(NewEmployeeShiftEndRequestDto model)
        {
            try
            {
                int storageId = 0;

                var shiftEnd = new ShiftEndReport();
                shiftEnd.CompanyMoneyTransferred = model.CompanyMoneyTransferred;
                shiftEnd.UserId = model.UserId;
                shiftEnd.ShiftId = model.ShiftId;

                _context.ShiftEndReports.Add(shiftEnd);
                _context.SaveChanges();

                foreach (var item in model.AuditDetails)
                {
                    var auditDetail = new InventoryAuditDetail();
                    var storage = GetProductStorageDto(item.ProductId);

                    auditDetail.ShiftEndId = shiftEnd.ShiftEndId;
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
                    cahsDetail.ShiftEndId = shiftEnd.ShiftEndId;
                    cahsDetail.Denomination = item.Denomination;
                    cahsDetail.Amount = item.Amount;

                    _context.ShiftHandoverCashDetails.Add(cahsDetail);
                }

                var shiftResult = ExportShiftHandover(shiftEnd.ShiftEndId, storageId);

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = model.UserId.Value,
                    Action = "Add ShiftEndReport: " + shiftEnd.ShiftEndId.ToString(),
                    Source = "ShiftEndReport",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return shiftEnd;
            }
            catch (Exception ex)
            {
                var errorLogger = new ErrorLogger(GenerateFilePath());
                errorLogger.LogError("Function CreateShiftEndReport: " + ex.Message);

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

        public ProductStorageInformationDto GetProductStorageDto(int productId)
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

        private async Task<bool> ExportShiftHandover(int shiftEndId, int storageId)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(string.Format("EXEC dbo.sp_generate_shift_handover {0}, {1}", shiftEndId, storageId));

                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        #endregion
    }
}
