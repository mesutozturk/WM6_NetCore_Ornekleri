using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kuzey.BLL.Account;
using Kuzey.Models.ViewModels;
using Kuzey.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kuzey.UI.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MembershipTools _membershipTools;
        private readonly IConfiguration _configuration;

        public AccountController(MembershipTools membershipTools, IConfiguration configuration)
        {
            _membershipTools = membershipTools;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> GetToken(LoginViewModel model)
        {
            var user = await _membershipTools.UserManager.FindByNameAsync(model.UserName);
            var result = await _membershipTools.UserManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return Unauthorized();
            }
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();

            var appSettingsSection = _configuration.GetSection("AppSettings");

            var key = Encoding.ASCII.GetBytes(appSettingsSection.Get<AppSettings>().Secret);
            var expires = DateTime.UtcNow.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenText = tokenHandler.WriteToken(token);



            return Ok(new TokenModel()
            {
                access_token = tokenText,
                issued = DateTime.UtcNow,
                userName = model.UserName,
                expires = expires,
                expires_in = (expires - DateTime.UtcNow).Ticks,
                token_type = "bearer"
            });
        }
    }
}