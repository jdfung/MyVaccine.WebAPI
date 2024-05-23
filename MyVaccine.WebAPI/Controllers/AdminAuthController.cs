using Microsoft.AspNetCore.Mvc;
using MyVaccine.Core;
using MyVaccine.DB;

namespace MyVaccine.WebAPI.Controllers
{
    public class AdminAuthController : Controller
    {
        private readonly IAdminAuthServices _services;

        public AdminAuthController(IAdminAuthServices services)
        {
            _services = services;
        }

        [HttpPost("register")]
        public IActionResult RegisterAdmin(string username, string password)
        {
            var response = _services.RegisterAdmin(username, password);
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult LoginAdmin(string username, string password)
        {
            var response = _services.LoginAdmin(username, password);
            return Ok(response);
        }
    }
}
