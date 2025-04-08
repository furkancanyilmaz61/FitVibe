using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FitVibe.Data.Entities;
using FitVibe.Business.Operations.User;
using FitVibe.Business.Operations.Admin;

namespace FitVibe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register-admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(AdminRegisterDTO model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "ADMIN");

            return Ok("Admin başarıyla oluşturuldu.");
        }

        [HttpGet("all-users")]
        public IActionResult AllUsers()
        {
            return Ok("Tüm kullanıcı listesi (dummy).");
        }

        [HttpGet("admin-dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("Sadece admin paneli için görünür veri.");
        }
    }
}
