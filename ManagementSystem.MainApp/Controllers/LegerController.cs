using ManagementSystem.Common.GenericModels;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegerController : ControllerBase
    {
        private string APIUrl = Environment.AccountingApiUrl + "Leger/";


        [HttpPost("search_results")]
        public async Task<IActionResult> SearchLegers([FromBody] SearchCriteria searchModel)
        {

            var result = await HttpRequestsHelper.Post<TPagination<LegerResponseDto>>(APIUrl + "search_results", searchModel);

            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
        }

        [HttpPost("export_excel")]
        public async Task<IActionResult> ExportExcelFile([FromBody] SearchCriteria searchModel)
        {
            var result = await HttpRequestsHelper.Post<ResponseDto>(SD.AccountingApiUrl + "Leger/export_excel", searchModel);

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
    }
}
