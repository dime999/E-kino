﻿using AutoMapper.Configuration;
using KinoAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace KinoAPI.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;




        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IConfiguration configuration)
        {
            this.configuration = configuration;
            this._userManager=userManager;
            this.signInManager=signInManager;
        }


        [HttpPost("create")]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody] UserCredentials userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Email, Email = userCredentials.Email };
            var result = await _userManager.CreateAsync(user,userCredentials.Password);

            if (result.Succeeded)
            {
                return await BuildToken(userCredentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(
          [FromBody] UserCredentials userCredentials)
        {
            var result = await signInManager.PasswordSignInAsync(userCredentials.Email,
                userCredentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(userCredentials);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }
        }

        private async Task<AuthenticationResponse> BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email)
            };

            var user = await _userManager.FindByNameAsync(userCredentials.Email);
            var claimsDB = await _userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Trajanje = expiration
            };
        }
    }
}
