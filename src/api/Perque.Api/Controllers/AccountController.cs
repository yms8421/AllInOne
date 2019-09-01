using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Perque.Api.Models;
using Perque.Contracts;

namespace Perque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly AppSettings.Token tokenOption;
        public AccountController(IOptions<AppSettings> options)
        {
            tokenOption = options.Value.Jwt;
        }
        [HttpPost("token")]
        public string GetToken([FromBody]LoginInfo info)
        {
            //var user = userservice.GetUser(info.UserName, info.Password);
            //if (user == null) { return string.Empty }
            var userClaims = new Claim[] {
                new Claim("uniqueName", info.UserName),
                new Claim("userId", "154"),
                //new Claim("userId", user.Id.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecretKey));
            var token = new JwtSecurityToken(
                issuer: tokenOption.Issuer,
                audience: tokenOption.Issuer,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return $"Bearer {tokenValue}";
        }
    }
}