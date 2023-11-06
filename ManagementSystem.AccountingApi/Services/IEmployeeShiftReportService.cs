using ManagementSystem.Common.Entities;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.AccountingApi.Services
{
    public interface IEmployeeShiftReportService
    {
        ShiftEndReport CreateShiftEndReport(NewEmployeeShiftEndRequestDto model);
        Task<TPagination<ShiftHandoverResponseDto>> GetAllShiftHandover(SearchCriteria criteria);
        Task<ShiftHandoverResponseDto> GetShiftHandover(int handoverId);
        Task<ShiftReportResponseDto> GetShiftReport(int shiftEndId);
        Task<TPagination<ShiftEndResponseDto>> SearchShiftEndReports(SearchCriteria criteria);
        Task<ShiftEndResponseDto> GetLastestShiftEnd();
        Task<ShiftEndResponseDto> GetShiftEndById(int shiftEndId);
        Task<bool> IsCompletedShiftEnd(int shiftId);
    }
}
