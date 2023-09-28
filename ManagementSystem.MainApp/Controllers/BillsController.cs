using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<ListBillResponse> bills = await HttpRequestsHelper.Get<List<ListBillResponse>>(Environment.StorageApiUrl + "bills/get");
            if (bills != null || bills.Count > 0)
            {
                return Ok(bills);
            }
            return Ok("Bills not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BillInfo bill)
        {
            var resultBill = await HttpRequestsHelper.Post<int>(Environment.StorageApiUrl + "bills/create", bill);
            if (resultBill != 0) 
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

                // Tao Phieu Xuat Kho
                var inventoryVoucherDto = PrepareInventoryModel(bill);
                inventoryVoucherDto.UserId = int.Parse(userId);
                inventoryVoucherDto.BillId = resultBill;

                var isCreated = await HttpRequestsHelper.Post<bool>(Environment.AccountingApiUrl + "InventoryVoucher/create", inventoryVoucherDto);

                return Ok(isCreated);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong when create bill");
        }

        // Create private function Handler.
        private NewInventoryVoucherDto PrepareInventoryModel(BillInfo bill)
        {
            var model = new NewInventoryVoucherDto();

            model.CustomerId = bill.CustomerId;
            model.PurchasingRepresentive = bill.CustomerId == null ? "" : bill.CustomerName;
            model.EmployeeShiftId = bill.EmployeeShiftId;
            model.BrandId = bill.BrandId;
            model.PaymentMethodCodes = bill.Payments.Select(x => x.PaymentMethodCode).ToList();
            
            var inventoryDetails = new List<InventoryVoucherDetailDto>();
            foreach (var item in bill.Details)
            {
                var inventoryDetail = new InventoryVoucherDetailDto();

                inventoryDetail.ProductId = item.ProductId;
                inventoryDetail.Quantity = item.Quantity;
                inventoryDetail.TotalMoneyAfterTax = item.Amount;
                inventoryDetail.UnitId = item.UnitId;

                inventoryDetails.Add(inventoryDetail);
            }

            model.Details = inventoryDetails;
            return model;
        }
    }
}
