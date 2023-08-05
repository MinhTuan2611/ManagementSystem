using ManagementSystem.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.MainApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("Get")]
        public IActionResult Get()
        {
            //var requestProd = new HttpRequestMessage(HttpMethod.Post, "http://api.tdfoodmartv2.tiha.vn/api/hanghoa/danhsach-hanghoa");
            //requestProd.Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            //var resprod = await httpClient.SendAsync(requestProd);
            //if (resprod.IsSuccessStatusCode)
            //{
            //    try
            //    {
            //        var contentProd = await resprod.Content.ReadAsStringAsync();
            //        var formatContent = JsonConvert.DeserializeObject<ApiResult>(contentProd);
            //        if (formatContent.data == null)
            //        {
            //            if (lastUpdateTime == null)
            //            {
            //                lastUpdateTime = new Configuation
            //                {
            //                    Name = "lastProductSyncDataTime",
            //                    ValueDateTime = DateTime.Now,
            //                };
            //                _context.Configuations.Add(lastUpdateTime);
            //            }
            //            else
            //            {
            //                lastUpdateTime.ValueDateTime = DateTime.Now;
            //                _context.Configuations.Update(lastUpdateTime);
            //            }

            //            _context.SaveChanges();
            //            return RedirectToAction(nameof(Index));
            //        }
                    return StatusCode(StatusCodes.Status404NotFound, "Products not found");
        }

        // GET api/user/Register
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserRegister user)
        {
      
            return StatusCode(StatusCodes.Status500InternalServerError, "Invalid create user");
        }
    }
}
