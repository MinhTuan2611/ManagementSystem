

using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : ControllerBase
    {
        private IRefundService _refundService;

        public RefundController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateRefundBill(BillRefundRequestDto model)
        {
            //var contentProcess = new ResponseDto();
            //if (model.ExchangedProduct != null)
            //{
            //    var listItem = new List<InventoryVoucherDetailDto>();
            //    foreach(var item in model.ExchangedProduct) {
            //        var product = new InventoryVoucherDetailDto()
            //        {
            //            ProductId = item.ProductId,
            //            Quantity = item.Quantity,
            //            UnitId = item.UnitId,
            //            TotalMoneyAfterTax = item.Quantity * item.Price
            //        };
            //        listItem.Add(product);
            //    }
            //    var InventoryModel = new NewInventoryVoucherDto()
            //    {
            //        BrandId = model.BranchId,
            //        CustomerId = model.CustomerId,
            //        CustomerName = model.CustomerName,
            //        UserId = model.UserId,
            //        Details = listItem
            //    };
            //   await _inventoryVoucherService.CreateInventoryVoucher(InventoryModel,true);
            //}

            //if(model.TotalDeductibleAmount > 0){
            //    var receiptModel = new NewReceiptRequestDto()
            //    {
            //         CustomerId = model.CustomerId,
            //         CustomerName = model.CustomerName,
            //         ForReason = model.ForReason,
            //         TotalMoney = model.TotalDeductibleAmount,
            //         UserId = model.UserId,
            //    };
            //    await _receiptService.CreateReceipt(receiptModel);  

            //}else if(model.TotalDeductibleAmount < 0)
            //{
            //    var paymentModel = new NewPaymentVoucherDto()
            //    {
            //        BranchId = model.BranchId,
            //        ReceiverName = model.CustomerName,
            //        TotalMoneyVND = model.TotalDeductibleAmount,
            //        Reason = model.ForReason,
            //        UserId = model.UserId,
            //        ShiftId = model.ShiftId,
            //    };
            //    await _paymentVoucherService.CreatePaymentVoucher(paymentModel);
            //}

            //if (model.ReturnedProduct != null)
            //{
            //    contentProcess = await _storageVoucherService.CreateProductStorage(model);
            //}

            //return Ok(contentProcess);

            // _refundService.CreateRefundVoucher(model);
            return Ok(model);
        }
    }
}