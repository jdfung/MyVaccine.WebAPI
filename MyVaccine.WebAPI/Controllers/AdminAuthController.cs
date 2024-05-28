using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyVaccine.Core;
using MyVaccine.DB;
using System;
using System.Net;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyVaccine.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyVaccinePolicy")]
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
            var accessToken = response[0];
            var refreshToken = response[1];

            SetRefreshTokenCookie(refreshToken);

            return Ok(new { AccessToken = accessToken });
        }

        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken()
        {
            var refreshToken = HttpContext.Request.Cookies["RefreshToken"];
            if(refreshToken == null)
            {
                return Unauthorized();
            }
            var validate = _services.ValidateToken(refreshToken);
            if (!validate)
            {
                return Unauthorized();
            }
            var accessToken = _services.CreateAccessToken();
            return Ok(new { AccessToken = accessToken });
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            var cookie = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1),
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                Secure = true,
                Path = "/"
            };
            Response.Cookies.Append("RefreshToken", string.Empty, cookie);

            return Ok(new { message = "Refresh Token is removed" });
        }

        private void SetRefreshTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(1),
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                Secure = true
            };
            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }

    }
}
