using ManagementSystem.Common.Models.Dtos;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IElectronicService
    {
        Task<ElectronicPattern> GetLastestPattern();
    }
}
