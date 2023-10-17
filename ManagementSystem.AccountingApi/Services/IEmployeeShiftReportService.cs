using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IEmployeeShiftReportService
    {
        Task<ShiftEndReport> CreateShiftEndReport(NewEmployeeShiftEndRequestDto model);
    }
}
