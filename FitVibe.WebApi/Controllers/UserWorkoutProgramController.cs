using FitVibe.Business.Operations.UserWorkoutProgram;
using FitVibe.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitVibe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutProgramController : ControllerBase
    {
        private readonly IUserWorkoutProgramService _userWorkoutProgramService;

        public UserWorkoutProgramController(IUserWorkoutProgramService userWorkoutProgramService)
        {
            _userWorkoutProgramService = userWorkoutProgramService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserWorkoutProgramCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userWorkoutProgramService.CreateAsync(dto);

            if (!result)
                return BadRequest("Kullanıcı veya program bulunamadı ya da zaten kayıtlı.");

            return Ok("Kayıt başarıyla eklendi.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userWorkoutProgramService.GetAllAsync();
            return Ok(list);
        }
    }
}
