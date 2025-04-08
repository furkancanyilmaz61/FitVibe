using FitVibe.Business.Operations.Coach;
using FitVibe.Data.Entities;

public interface ICoachService
{
    Task<Coach> CreateAsync(CoachCreateDTO dto);
    Task<List<Coach>> GetAllAsync();
}
