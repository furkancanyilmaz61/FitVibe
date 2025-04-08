using FitVibe.Business.Operations.Coach;
using FitVibe.Data.Context;
using FitVibe.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class CoachService : ICoachService
{
    private readonly FitVibeDbContext _context;

    public CoachService(FitVibeDbContext context)
    {
        _context = context;
    }

    public async Task<Coach> CreateAsync(CoachCreateDTO dto)
    {
        var coach = new Coach { FullName = dto.FullName };
        _context.Coaches.Add(coach);
        await _context.SaveChangesAsync();
        return coach;
    }

    public async Task<List<Coach>> GetAllAsync()
    {
        return await _context.Coaches.ToListAsync();
    }
}
