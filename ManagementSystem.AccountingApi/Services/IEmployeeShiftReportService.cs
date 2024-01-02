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
        Task<ShiftEndResponseDto> GetLastestShiftEnd(int? branchId);
        Task<ShiftEndResponseDto> GetShiftEndById(int shiftEndId);
        Task<int> IsCompletedShiftEnd(int shiftId);
        Task<bool> IsCanStartShiftEnd(int branchId);
        Task<bool> CanProcessShiftEnd(int branchId);
        Task<int> GetCurrentShift(int branchId);
        Task<ResponsePagingModel<ShiftEndReport>> StartShiftEnd(StartShiftEndRequestDto request);
    }
}
