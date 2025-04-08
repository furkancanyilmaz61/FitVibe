using FitVibe.Data.Context;
using FitVibe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FitVibe.Business.Operations.WorkoutProgram;

namespace FitVibe.Business.Services.Implementations
{
    public class WorkoutProgramService : IWorkoutProgramService
    {
        private readonly FitVibeDbContext _context;

        public WorkoutProgramService(FitVibeDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutProgram>> GetAllAsync()
        {
            return await _context.WorkoutPrograms.Include(w => w.Coach).ToListAsync();
        }

        public async Task<WorkoutProgram?> GetByIdAsync(int id)
        {
            return await _context.WorkoutPrograms.Include(w => w.Coach)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkoutProgram> CreateAsync(WorkoutProgramCreateDTO dto)
        {
            var workout = new WorkoutProgram
            {
                Title = dto.Title,
                Description = dto.Description,
                DurationInDays = dto.DurationInDays,
                CoachId = dto.CoachId
            };

            _context.WorkoutPrograms.Add(workout);
            await _context.SaveChangesAsync();

            return workout;
        }

        public async Task<bool> UpdateAsync(WorkoutProgramUpdateDTO dto)
        {
            var workout = await _context.WorkoutPrograms.FindAsync(dto.Id);
            if (workout == null) return false;

            workout.Title = dto.Title;
            workout.Description = dto.Description;
            workout.DurationInDays = dto.DurationInDays;
            workout.CoachId = dto.CoachId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var workout = await _context.WorkoutPrograms.FindAsync(id);
            if (workout == null) return false;

            _context.WorkoutPrograms.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
