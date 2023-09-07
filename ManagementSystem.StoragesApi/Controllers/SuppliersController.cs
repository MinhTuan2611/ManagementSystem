using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(StoragesDbContext context)
        {
            _suppliersService = new SuppliersService(context);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var suppliers = _suppliersService.GetListSupplieres();
            if (suppliers != null)
            {
                var lsSuppliers = suppliers as List<Supplier> ?? suppliers.ToList();
                if (lsSuppliers.Any())
                    return Ok(lsSuppliers);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Products not found");
        }
        [HttpGet("autocomplete-suppliers-by-name")]
        public IActionResult AutoCompleteSupplieresByName(string? searchValue)
        {
            var suppliers = _suppliersService.AutoCompleteSupplieresByName(searchValue);
            if (suppliers != null)
            {
                var lsSuppliers = suppliers as List<Supplier> ?? suppliers.ToList();
                if (lsSuppliers.Any())
                    return Ok(lsSuppliers);
            }
            return Ok(new List<Supplier>());
        }

        [HttpPost("create")]
        public IActionResult Create(Supplier supplier)
        {
            var newSupplier = _suppliersService.CreateSupplier(supplier);
            if (newSupplier != null)
            {
                return Ok(newSupplier);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateSupplierModel supplier)
        {
            bool updated = _suppliersService.UpdateSupplier(supplier.SupplierId, supplier.Supplier, supplier.UserId);
            return Ok(updated);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SupplierRequest request)
        {
            bool updated = _suppliersService.DeleteSupplier(request.SupplierId, request.UserId);
            return Ok(updated);
        }
    }
}
