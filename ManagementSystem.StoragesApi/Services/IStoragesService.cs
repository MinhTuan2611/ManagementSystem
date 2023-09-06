using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IStoragesService
    {
        IEnumerable<Storage> GetListStorages();

        Storage GetStorageByCode(string storageCode);

        Storage GetStorageById(int storageId);

        IEnumerable<Storage> AutoCompleteStorage(string? valueSearch);

        Storage CreateStorage(Storage storage);

        bool UpdateStorage(int storageId, StorageInfo storage, int? userId);
        bool DeleteStorage(int storageId, int? userId);
    }
}
