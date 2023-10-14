﻿using ManagementSystem.AccountingApi.Services;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.Accounting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
        {
            var result = await _service.GetInventoryVouchers(page.Value, pageSize.Value);
            return Ok(result);
        }

        [HttpGet("get-by-document-number")]
        public async Task<IActionResult> GetByDocumentNumber([FromQuery] int DocumentNumber)
        {
            var result = await _service.GetInventoryVoucherDetail(DocumentNumber);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewInventoryVoucherDto request)
        {
            var inventory = await _service.CreateInventoryVoucher(request);
            if (inventory != null)
            {
                var newReceiptDto = new NewReceiptRequestDto()
                {
                    CustomerId = request.CustomerId,
                    ForReason = string.Format(AccountingConstant.ReceiptReason, inventory.DocummentNumber),
                    UserId = request.UserId,
                    TotalMoney = request.Details.Sum(x => x.TotalMoneyAfterTax),
                    CreditAccountId = inventory.Details.SingleOrDefault(x => x.CreditAccount != null)?.CreditAccount,
                    DebitAccountId = inventory.Details.SingleOrDefault(x => x.DebitAccount != null)?.DebitAccount,
                    BillId = request.BillId,
                    StorageId = inventory.Details.SingleOrDefault(x => x.StorageId != null).StorageId
                };
                
                var receptResult = await  _receiptService.CreateReceipt(newReceiptDto);


                return Ok(receptResult);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong When create Inventory Voucher or the product is not enough in the storage!");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateInventoryVoucherDto request)
        {
            var updated = await _service.UpdateInventoryDeliveryVoucher(request);
            return Ok(updated);
        }
    }
}
