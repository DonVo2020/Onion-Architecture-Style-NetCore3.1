using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.AuthService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser>
            userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.Single(r => r.Email == model.Email);
                var roles = await userManager.GetRolesAsync(appUser);
                var role = roleManager.Roles.SingleOrDefault(r => r.Name == roles.SingleOrDefault());

                if (appUser.Active)
                {
                    if (role.Id != model.Role.ToString())
                    {
                        return Unauthorized(new { Message = "Invalid user data. Please verify your role." });
                    }
                    var response = await GenerateJwtToken(model.Email, appUser);
                    return Ok(response);
                }
                return BadRequest(new { Message = "You have been blocked by administrator." });
            }
            return BadRequest(new { Message = "Invalid Credentials." });
        }

        [Route("logout")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] LoginDTO model)
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                //InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "LogOut Failed");
            }
            return Ok();
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Active = true,
            };

            try
            {

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //role
                    var roleName = roleManager.Roles.FirstOrDefault(
                        r => r.Id == model.Role.ToString()).NormalizedName;

                    var result1 = await userManager.AddToRoleAsync(user, roleName);
                    if (result1.Succeeded)
                    {
                        //  return Created("Registered", model.Email);
                        var response = await GenerateJwtToken(model.Email, user);

                        return Ok(response);
                    }
                    return BadRequest(result1.Errors);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return BadRequest(new { Message = "Invalid Credentials." });
        }

        private async Task<TokenDTO> GenerateJwtToken(string email, ApplicationUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var role = roleManager.Roles.SingleOrDefault(r => r.Name == roles.SingleOrDefault());
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,role.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration["JwtKey"]));
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(
                Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds);

            try
            {
                var response = new TokenDTO
                {
                    Key = new JwtSecurityTokenHandler().WriteToken(token),
                    Email = email
                };
                return response;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }

            //return response;
        }
    }
}
