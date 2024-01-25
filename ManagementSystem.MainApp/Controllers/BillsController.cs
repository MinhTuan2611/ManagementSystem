using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.MainApp.Services;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Constants;
using ManagementSystem.MainApp.Utility;
using ManagementSystem.MainApp.Services.IServices;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly INotificationsServices _serverSentEventsServices;
        private readonly IPaymentServices _paymentServices;
        private readonly IInventoryVoucherService _inventoryService;

        public BillsController(INotificationsServices serverSentEventsServices, IPaymentServices paymentService, IInventoryVoucherService inventoryVoucherService)
        {
            _serverSentEventsServices = serverSentEventsServices;
            _paymentServices = paymentService;
            _inventoryService = inventoryVoucherService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            List<ListBillResponse> bills = await HttpRequestsHelper.Get<List<ListBillResponse>>(SD.StorageApiUrl + "bills/get");
            if (bills != null || bills.Count > 0)
            {
                return Ok(bills);
            }
            return Ok("Bills not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BillInfo bill)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            bill.UserId = userId;

            var resultBill = await HttpRequestsHelper.Post<BillInfo>(SD.StorageApiUrl + "bills/create", bill);
            if (resultBill != null)
            {
                // Tao Phieu Xuat Kho
                var inventoryVoucherDto = PrepareInventoryModel(bill);
                inventoryVoucherDto.UserId = userId;
                inventoryVoucherDto.BillId = resultBill.BillId;

                var inventoryResult = await _inventoryService.CreateInventory(inventoryVoucherDto);

                if (inventoryResult.IsSuccess == false)
                {
                    var deleteBillFlags = await HttpRequestsHelper.Delete<bool>(SD.StorageApiUrl + $"bills/delete/{resultBill.BillId}/{userId}", resultBill.BillId);
                    return StatusCode(StatusCodes.Status500InternalServerError, inventoryResult.Message);
                }

                // Update Customer Point
                if (bill.CustomerId != null)
                {
                    var customerUpdate = new UpdateCustomerPointDto()
                    {
                        CustomerId = bill.CustomerId,
                        Amount = bill.Details.Sum(c => c.Amount),
                        UsedPoint = bill.Payments.FirstOrDefault(x => x.PaymentMethodCode == "POINT")?.Point
                    };

                    var customerUpdateFlag = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "customers/update_point", customerUpdate);
                    //if (!customerUpdateFlag)
                    //    return StatusCode(StatusCodes.Status500InternalServerError, "The bill is created, inventory created but faild when Update customer point");


                }

                var paymentMethods = bill.Payments.Where(x => x.PaymentMethodCode != StorageContant.CashPaymentMethodCode).ToList();
                if (paymentMethods.Count > 0)
                {
                    bill.BillId = resultBill.BillId;
                    var creditVouchers = await GenerateVoucherWithAnotherPaymentMethods(bill, userId);

                    if (creditVouchers.Count == 0)
                        return StatusCode(StatusCodes.Status500InternalServerError, "The bill is created, inventory created, customer update point but faild when create Credit Voucher");
                }

                return Ok(resultBill);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong when create bill");
        }

        [HttpPost("complete-bill")]
        public async Task<IActionResult> CompleteBill(BillInfo bill)
        {
            var response = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "bills/complete-bill", bill);
            if (response)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong");
        }
        [HttpPost("momo-ipn")]
        public async Task<IActionResult> MomoIPN([FromBody] MomoRequestIPN request)
        {
            //var response = await HttpRequestsHelper.Post<bool>(SD.StorageApiUrl + "bills/check-momo-payment", request);
            if (request.ResultCode == 0)
            {
                await _serverSentEventsServices.SendMessageAsync("MOMO_TRACKING", request.OrderId, "Completed");
            }
            else
            {
                await _serverSentEventsServices.SendMessageAsync("MOMO_TRACKING", "1234", request.Message);
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPost("momo-create-transaction")]
        public async Task<IActionResult> MomoCreateTransaction([FromBody] MomoCreateTransactionRequest request)
        {
            QuickPayResponse result = await _paymentServices.MomoCreatePayment(request.OrderId, request.Amount);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong when create bill");
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost("search_results")]
        public async Task<IActionResult> SearchBills([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<BillSearchingResponseDto>>(SD.StorageApiUrl + "bills/search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetBillDetail([FromQuery] int billId)
        {

            ResponseModel<BillResponseDto> response = new ResponseModel<BillResponseDto>();
            var result = await HttpRequestsHelper.Get<BillResponseDto>(SD.StorageApiUrl + "bills/get-detail?billId=" + billId);

            var resultResponse = new List<BillResponseDto>();
            resultResponse.Add(result);

            if (result != null)
            {

                response.Status = "success";
                response.Data = resultResponse;
                return Ok(response);
            }

            response.Status = "success";
            response.ErrorMessage = "Not found any information!";
            return Ok(response);
        }

        [HttpPost("update-bill")]
        public async Task<IActionResult> UpdateBill([FromBody] UpdateBillRequestDto model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            model.UserId = int.Parse(userId);

            var resultBill = await HttpRequestsHelper.Post<BillInfo>(SD.StorageApiUrl + "bills/update-bill", model);
            if (resultBill != null)
                return Ok(resultBill);

            return StatusCode(StatusCodes.Status500InternalServerError, "Some thing went wrong when Update bill");
        }

        [HttpPost("export_discount_information_excel")]
        public async Task<IActionResult> ExportDiscountInformationExcel([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<ResponseDto>(SD.StorageApiUrl + "bills/export_discount_information_excel", searchModel);

            if (result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            string filePath = result.Result.ToString();
            // Set the content type based on the file type
            string contentType = "application/octet-stream";

            // Set the file name displayed in the download dialog
            string fileName = Path.GetFileName(filePath);


            // Create a FileStreamResult with the file stream
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            var response = File(fileStream, contentType, fileName);

            // Register a callback to close the stream after the response is sent
            Response.OnCompleted(() =>
            {
                fileStream.Dispose();

                // Delete the file after it has been downloaded
                System.IO.File.Delete(filePath);

                return Task.CompletedTask;
            });

            return response;
        }

        [HttpPost("view_discount_informations")]
        public async Task<IActionResult> ViewDiscountInformations([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<List<DiscountInformationDto>>(SD.StorageApiUrl + "bills/view_discount_informations", searchModel);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpPost("export_revenue_information_excel")]
        public async Task<IActionResult> ExportRevenueInformationExcel([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<ResponseDto>(SD.StorageApiUrl + "bills/export_revenue_information_excel", searchModel);

            if (result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            string filePath = result.Result.ToString();
            // Set the content type based on the file type
            string contentType = "application/octet-stream";

            // Set the file name displayed in the download dialog
            string fileName = Path.GetFileName(filePath);


            // Create a FileStreamResult with the file stream
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            var response = File(fileStream, contentType, fileName);

            // Register a callback to close the stream after the response is sent
            Response.OnCompleted(() =>
            {
                fileStream.Dispose();

                // Delete the file after it has been downloaded
                System.IO.File.Delete(filePath);

                return Task.CompletedTask;
            });

            return response;
        }

        [HttpPost("view_revenue_informations")]
        public async Task<IActionResult> ViewRevenueInformations([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<List<BillRevenueInformationDto>>(SD.StorageApiUrl + "bills/view_revenue_informations", searchModel);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpDelete("{billId}")]
        public async Task<IActionResult> DeleteBill(int billId)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

            var deleteBillFlags = await HttpRequestsHelper.Delete<bool>(SD.StorageApiUrl + $"bills/delete/{billId}/{userId}", billId);

            return Ok();
        }

        [HttpPost("export_bill_detail_excel")]
        public async Task<IActionResult> ExportBillDetailExcel([FromBody] string lístBillId)
        {
            var result = await HttpRequestsHelper.Post<ResponseDto>(SD.StorageApiUrl + "bills/export_bill_detail_excel", lístBillId);

            if (result.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            string filePath = result.Result.ToString();
            // Set the content type based on the file type
            string contentType = "application/octet-stream";

            // Set the file name displayed in the download dialog
            string fileName = Path.GetFileName(filePath);


            // Create a FileStreamResult with the file stream
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            var response = File(fileStream, contentType, fileName);

            // Register a callback to close the stream after the response is sent
            Response.OnCompleted(() =>
            {
                fileStream.Dispose();

                // Delete the file after it has been downloaded
                System.IO.File.Delete(filePath);

                return Task.CompletedTask;
            });

            return response;
        }
        #region Private handle function
        // Create private function Handler.
        private NewInventoryVoucherDto PrepareInventoryModel(BillInfo bill)
        {
            var model = new NewInventoryVoucherDto();

            model.CustomerId = bill.CustomerId;
            model.PurchasingRepresentive = bill.CustomerId == null ? "" : bill.CustomerName;
            model.EmployeeShiftId = bill.EmployeeShiftId;
            model.BrandId = bill.BranchId;

            var inventoryDetails = new List<InventoryVoucherDetailDto>();
            foreach (var item in bill.Details)
            {
                var inventoryDetail = new InventoryVoucherDetailDto();

                inventoryDetail.ProductId = item.ProductId;
                inventoryDetail.Quantity = item.Quantity;
                inventoryDetail.TotalMoneyAfterTax = item.Amount;
                inventoryDetail.UnitId = item.UnitId;
                inventoryDetail.PaymentDiscountMoney = item.DiscountAmount;

                inventoryDetails.Add(inventoryDetail);
            }
            model.CashPaymentAmount = bill.Payments.Where(x => x.PaymentMethodCode == StorageContant.CashPaymentMethodCode).Sum(x => x.Amount);
            
            model.Details = inventoryDetails;
            return model;
        }

        private async Task<List<CreditVoucher>> GenerateVoucherWithAnotherPaymentMethods(BillInfo bill, int userId)
        {
            var paymentMethods = bill.Payments.Where(x => x.PaymentMethodCode != StorageContant.CashPaymentMethodCode);
            List<CreditVoucher> creditVouchers = new List<CreditVoucher>();

            foreach (var item in paymentMethods)
            {
                var creditVoucher = new NewCreditVoucherRequestDto()
                {
                       CustomerId = bill.CustomerId,
                       TotalMoney = item.Amount,
                       UserId = userId,
                       BillId = bill.BillId,
                       BrandId = bill.BranchId != null ? bill.BranchId : 0,
                       PaymentMethodCode = item.PaymentMethodCode,
                       ProductId = bill.Details[0].ProductId,
                       GroupId = AccountingConstant.AutoGenerateDocumentGroup
                };

                var result = await HttpRequestsHelper.Post<CreditVoucher>(SD.AccountingApiUrl + "CreditVouchers/create", creditVoucher);

                if (result != null)
                {
                    creditVouchers.Add(result);
                }
            }

            return creditVouchers;
        }
        #endregion
    }
}
