using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class StoragesService : IStoragesService
    {
        private readonly UnitOfWork _unitOfWork;
        public StoragesService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Storage> GetListStorages()
        {
            List<Storage> listStorages = _unitOfWork.StorageRepository.GetMany(b => b.Status.Equals(ActiveStatus.Active)).ToList();
            if (listStorages.Any())
            {
                return listStorages;
            }
            return new List<Storage>();
        }

        public Storage CreateStorage(Storage storage)
        {
            try
            {
                _unitOfWork.StorageRepository.Insert(storage);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return storage;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Storage GetStorageByCode(string storageCode)
        {
            Storage storage = _unitOfWork.StorageRepository.Get(b => b.StorageCode.Equals(storageCode));
            return storage;
        }
        public Storage GetStorageById(int storageId)
        {
            Storage storage = _unitOfWork.StorageRepository.Get(b => b.StorageId.Equals(storageId));
            return storage;
        }
        public bool UpdateStorage(int storageId, StorageInfo storage, int? userId)
        {
            Storage storageCur = _unitOfWork.StorageRepository.Get(b => b.StorageId.Equals(storageId));
            storageCur.StorageCode = storage.StorageCode;
            storageCur.StorageName = storage.StorageName;
            storageCur.Address = storage.Address;
            storageCur.Phone = storage.Phone;
            storageCur.ModifyDate = DateTime.Now;
            storageCur.ModifyBy = userId;
            try
            {
                _unitOfWork.StorageRepository.Update(storageCur);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteStorage(int storageId, int? userId)
        {
            Storage storage = _unitOfWork.StorageRepository.GetByID(storageId);
            storage.Status -= ActiveStatus.Inactive;
            storage.ModifyDate = DateTime.Now;
            storage.ModifyBy = userId;
            try
            {
                _unitOfWork.StorageRepository.Update(storage);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
