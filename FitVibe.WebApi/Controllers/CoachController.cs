using FitVibe.Business.Operations.Coach;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CoachController : ControllerBase
{
    private readonly ICoachService _coachService;

    public CoachController(ICoachService coachService)
    {
        _coachService = coachService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CoachCreateDTO dto)
    {
        var coach = await _coachService.CreateAsync(dto);
        return Ok(coach);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var coaches = await _coachService.GetAllAsync();
        return Ok(coaches);
    }
}
