using FitVibe.Business.Operations.WorkoutProgram;
using FitVibe.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitVibe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutProgramController : ControllerBase
    {
        private readonly IWorkoutProgramService _service;

        public WorkoutProgramController(IWorkoutProgramService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var programs = await _service.GetAllAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var program = await _service.GetByIdAsync(id);
            if (program == null)
                return NotFound();

            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkoutProgramCreateDTO dto)
        {
            var createdProgram = await _service.CreateAsync(dto);
            if (createdProgram == null)
                return BadRequest("Program oluşturulamadı.");

            return Ok(createdProgram); // başarıyla oluşan programı dön
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] WorkoutProgramUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID eşleşmiyor.");

            var result = await _service.UpdateAsync(dto);
            return result ? Ok("Güncelleme başarılı.") : NotFound("Program bulunamadı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Silme başarılı.") : NotFound("Program bulunamadı.");
        }
    }
}
