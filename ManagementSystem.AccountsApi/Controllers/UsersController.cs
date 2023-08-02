using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data;
using ManagementSystem.EmployeesApi.Data.Entities;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManagementSystem.AccountsApi.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IUsersService _UsersService;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public UsersController(AccountsDbContext context)
        {
            _UsersService = new UsersService(context);
        }
        #endregion
        // GET api/product
        public HttpResponseMessage Get()
        {
            var users = _UsersService.GetAllUsers();
            if (users != null)
            {
                var UsersEntities = users as List<User> ?? users.ToList();
                if (UsersEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, UsersEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

    }
}