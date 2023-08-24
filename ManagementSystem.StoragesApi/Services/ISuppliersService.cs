using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface ISuppliersService
    {
        IEnumerable<Supplier> GetListSupplieres();

        Supplier GetSupplierByCode(string branchCode);

        Supplier GetSupplierById(int supplierId);

        Supplier CreateSupplier(Supplier supplier);

        bool UpdateSupplier(int supplierId, SupplierInfo supplier, int? userId);
        bool DeleteSupplier(int supplierId, int? userId);
    }
}
