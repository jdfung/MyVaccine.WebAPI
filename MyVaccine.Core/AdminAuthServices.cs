using Azure.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public class AdminAuthServices : IAdminAuthServices
    {
        private readonly AppDBContext _context;

        private readonly IOptions<GetAppSettings> _configurations;


        public static Admin admin = new Admin();
        public AdminAuthServices(AppDBContext context, IOptions<GetAppSettings> configurations)
        {
            _context = context;
            _configurations = configurations;
        }

        public string CreateAccessToken()
        {
           
            //Get the secret key
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations.Value.AccessToken!));

            //signing creds
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var accessToken = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: Creds
                );

            //Write the token
            var jwtAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);
            return jwtAccess;
        }

        private string CreateRefreshToken()
        {
            
            //Get the secret key
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations.Value.RefreshToken!));

            //signing creds
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var RefreshToken = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: Creds
                );

            //Write the token
            var jwtRefresh = new JwtSecurityTokenHandler().WriteToken(RefreshToken);

            return jwtRefresh;
        }

        public Admin RegisterAdmin(string username, string password)
        {
            var verifyDupli = _context.admins.First(x => x.adminUserName == username);
            if (verifyDupli != null)
            {
                throw new InvalidOperationException("admin does not exist");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            admin.adminUserName = username;
            admin.adminPasswordHash = passwordHash;
            _context.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public string[] LoginAdmin(string username, string password)
        {
            var adminData = _context.admins.First(x => x.adminUserName == username);
            if (!BCrypt.Net.BCrypt.Verify(password, adminData.adminPasswordHash))
            {
                throw new InvalidOperationException("admin does not exist");
            }

            string AccessToken = CreateAccessToken();
            string RefreshToken = CreateRefreshToken();

            return [AccessToken, RefreshToken];
        }

        public bool ValidateToken(string Token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(Token, validationParameters, out validatedToken);
            return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations.Value.RefreshToken!)) // The same key as the one that generate the token
            };
        }

    }
}
