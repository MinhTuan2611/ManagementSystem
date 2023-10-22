using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IEmployeeShiftReportService
    {
        ShiftEndReport CreateShiftEndReport(NewEmployeeShiftEndRequestDto model);
        Task<List<ShiftHandoverResponseDto>> GetAllShiftHandover(SearchCriteria criteria);
        Task<ShiftHandoverResponseDto> GetShiftHandover(int handoverId);
        Task<ShiftReportResponseDto> GetShiftReport(int shiftEndId);
        Task<List<ShiftEndResponseDto>> SearchShiftEndReports(SearchCriteria criteria);
        Task<ShiftEndResponseDto> GetLastestShiftEnd();
    }
}
