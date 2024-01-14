using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace ManagementSystem.AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryVoucherController : ControllerBase
    {
        private readonly IInventoryVoucherService _service;
        private readonly IReceiptService _receiptService;
        public InventoryVoucherController(IInventoryVoucherService service, IReceiptService receiptService)
        {
            _service = service;
            _receiptService = receiptService;

        }

        [HttpPost("search_results")]
        public async Task<ResponseDto> SearchInventory([FromBody]SearchCriteria searchModel)
        {

            var result = await _service.SearchInventoryVouchers(searchModel);
            return result;
        }

        [HttpGet("get-detail-by-document-number")]
        public async Task<ResponseDto> GetDetailByDocumentNumber([FromQuery] int DocumentNumber)
        {
            var result = await _service.GetInventoryVoucherDetail(DocumentNumber);
            return result;
        }

        [HttpGet("get-by-document-number")]
        public async Task<ResponseDto> GetByDocumentNumber([FromQuery] int DocumentNumber)
        {
            var result = await _service.GetInventoryVoucherById(DocumentNumber);
            return result;
        }

        [HttpPost("create")]
        public async Task<ResponseDto> Create(NewInventoryVoucherDto request)
        {
            var inventory = await _service.CreateInventoryVoucher(request);
            if (inventory.Result != null && request.CashPaymentAmount > 0)
            {
                var iResponse = (InventoryVoucher)inventory.Result;
                var newReceiptDto = new NewReceiptRequestDto()
                {
                    CustomerId = request.CustomerId,
                    ForReason = string.Format(AccountingConstant.ReceiptReason, iResponse.DocummentNumber),
                    UserId = request.UserId,
                    TotalMoney = request.CashPaymentAmount,
                    BillId = request.BillId,
                    StorageId = iResponse.StorageId,
                    InventoryDocumentNumber = iResponse.DocummentNumber
                };
                
                var receptResult = await  _receiptService.CreateReceipt(newReceiptDto);

            }

            inventory.Result = null;
            return inventory;
        }

        [HttpPost("update")]
        public async Task<ResponseDto> Update(UpdateInventoryVoucherDto request)
        {
            var updated = await _service.UpdateInventoryDeliveryVoucher(request);
            updated.Result = null;
            return updated;
        }
    }
}
