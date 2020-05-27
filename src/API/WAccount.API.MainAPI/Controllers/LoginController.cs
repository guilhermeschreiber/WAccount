using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WAccount.API.MainAPI.Authentication;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;

        public LoginController(
            IUserLoginService userLoginService,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            _userLoginService = userLoginService;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Login(string email, string password)
        {
            UserAccount user = _userLoginService.Login(email, password);

            if (user != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.Name.ToString()),
                    new Claim("email", user.Email.ToString()),
                });

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now +
                        TimeSpan.FromSeconds(_tokenConfigurations.Seconds)
                });
                var token = handler.WriteToken(securityToken);

                this.Response.Headers.Add("Access-Control-Expose-Headers", "x-access-token");
                this.Response.Headers.Add("x-access-token", token);

                return Ok(user.Id);
            }
            return Unauthorized();
        }
    }
}
