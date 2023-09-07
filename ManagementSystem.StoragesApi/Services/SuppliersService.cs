using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly UnitOfWork _unitOfWork;
        public SuppliersService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Supplier> GetListSupplieres()
        {
            List<Supplier> listSuppliers = _unitOfWork.SupplierRepository.GetMany(s => s.Status.Equals(ActiveStatus.Active)).ToList();
            if (listSuppliers.Any())
            {
                return listSuppliers;
            }
            return new List<Supplier>();
        }

        public IEnumerable<Supplier> AutoCompleteSupplieresByName(string? valueSearch)
        {
            List<Supplier> listSuppliers = _unitOfWork.SupplierRepository.GetMany(s => s.Status.Equals(ActiveStatus.Active)
            && (s.DisplayName.ToLower().Contains(valueSearch.Trim().ToLower()) 
            || s.SupplierName.ToLower().Contains(valueSearch.Trim().ToLower()))).ToList();
            if (listSuppliers.Any())
            {
                return listSuppliers;
            }
            return new List<Supplier>();
        }

        public Supplier GetSupplierByCode(string supplierCode)
        {
            Supplier supplier = _unitOfWork.SupplierRepository.Get(s => s.SupplierCode.Equals(supplierCode));
            return supplier;
        }

        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = _unitOfWork.SupplierRepository.Get(b => b.SupplierId.Equals(supplierId));
            return supplier;
        }

        public Supplier CreateSupplier(Supplier supplier)
        {
            Supplier isExistSupplier = _unitOfWork.SupplierRepository.Get(s => s.SupplierCode.Equals(supplier.SupplierCode));

            if (isExistSupplier != null)
            {
                return null;
            }

            try
            {
                _unitOfWork.SupplierRepository.Insert(supplier);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return supplier;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateSupplier(int supplierId, SupplierInfo supplier, int? userId)
        {
            Supplier supplierCur = _unitOfWork.SupplierRepository.GetByID(supplierId);
            Supplier isExistSupplier = _unitOfWork.SupplierRepository.GetFirst(s => s.SupplierCode.Equals(supplier.SupplierCode));

            if(supplierCur.SupplierId == isExistSupplier.SupplierId)
            {
                return false;
            }
            supplierCur.SupplierCode = supplier.SupplierCode;
            supplierCur.SupplierName = supplier.SupplierName;
            supplierCur.Address = supplier.Address;
            supplierCur.Phone = supplier.Phone;
            supplierCur.DisplayName = supplier.DisplayName;

            try
            {
                _unitOfWork.SupplierRepository.Update(supplierCur);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteSupplier(int supplierId, int? userId)
        {
            Supplier supplier = _unitOfWork.SupplierRepository.GetByID(supplierId);
            supplier.Status = ActiveStatus.Inactive;
            supplier.ModifyDate = DateTime.Now;
            supplier.ModifyBy = userId;
            try
            {
                _unitOfWork.SupplierRepository.Update(supplier);
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
