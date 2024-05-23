using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
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

        private string CreateToken(Admin admin)
        {
            //To encode within the token
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.adminUserName)
            };

            //Get the secret key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations.Value.Token!));

            //signing creds
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            //Write the token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
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

        public string LoginAdmin(string username, string password)
        {
            var adminData = _context.admins.First(x => x.adminUserName == username);
            if (!BCrypt.Net.BCrypt.Verify(password, adminData.adminPasswordHash))
            {
                throw new InvalidOperationException("admin does not exist");
            }

            string token = CreateToken(adminData);

            return token;
        }
    }
}
