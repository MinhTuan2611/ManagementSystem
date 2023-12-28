

using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private readonly IReceiptService _receiptService;
        private readonly IInventoryVoucherService _inventoryVoucherService;
        private readonly IPaymentVoucherService _paymentVoucherService;
        private readonly IStorageVoucherService _storageVoucherService;

        public RefundController(
            IReceiptService receiptService,
            IInventoryVoucherService inventoryVoucherService,
            IPaymentVoucherService paymentVoucherService,
            IStorageVoucherService storageVoucherService
            )
        {
            _receiptService = receiptService;
            _inventoryVoucherService = inventoryVoucherService;
            _paymentVoucherService = paymentVoucherService;
             _storageVoucherService = storageVoucherService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateRefundBill(BillRefundRequestDto model)
        {
            if(model.ExchangedProduct != null){
                var listItem = new List<InventoryVoucherDetailDto>();
                foreach(var item in model.ExchangedProduct) {
                    var product = new InventoryVoucherDetailDto()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitId = item.UnitId,
                        TotalMoneyAfterTax = item.Quantity * item.Price
                    };
                    listItem.Add(product);
                }
                var InventoryModel = new NewInventoryVoucherDto()
                {
                    BrandId = model.BranchId,
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    UserId = model.UserId,
                    Details = listItem
                };
               await _inventoryVoucherService.CreateInventoryVoucher(InventoryModel,true);
            }

            if(model.ReturnedProduct != null) {
                await _storageVoucherService.CreateProductStorage(model.ReturnedProduct);
            }

            if(model.totalDeductibleAmount > 0){
                var receiptModel = new NewReceiptRequestDto()
                {
                     CustomerId = model.CustomerId,
                     CustomerName = model.CustomerName,
                     InventoryDocumentNumber = 1,
                     TotalMoney = model.totalDeductibleAmount,
                     UserId = model.UserId,
                };
                await _receiptService.CreateReceipt(receiptModel);  

            }else{
                var paymentModel = new NewPaymentVoucherDto()
                {
                    BranchId = model.BranchId,
                    ReceiverName = model.CustomerName,
                    TotalMoneyVND = model.totalDeductibleAmount,
                    UserId = model.UserId,
                    ShiftId = 1,
                    NTMoney = model.totalDeductibleAmount
                };
                await _paymentVoucherService.CreatePaymentVoucher(paymentModel);
            }
               
            return NoContent();
        }
    }
}