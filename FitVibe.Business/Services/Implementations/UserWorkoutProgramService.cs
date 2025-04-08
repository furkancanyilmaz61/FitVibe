using FitVibe.Business.Operations.UserWorkoutProgram;
using FitVibe.Data.Context;
using FitVibe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FitVibe.Business.Services.Interfaces;

namespace FitVibe.Business.Services.Implementations
{
    public class UserWorkoutProgramService : IUserWorkoutProgramService
    {
        private readonly FitVibeDbContext _context;

        public UserWorkoutProgramService(FitVibeDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserWorkoutProgramDTO>> GetAllAsync()
        {
            return await _context.UserWorkoutPrograms
                .Include(x => x.User)
                .Include(x => x.WorkoutProgram)
                .Select(x => new UserWorkoutProgramDTO
                {
                    UserId = x.UserId,
                    UserName = x.User.FullName,
                    WorkoutProgramId = x.WorkoutProgramId,
                    ProgramTitle = x.WorkoutProgram.Title
                })
                .ToListAsync();
        }

        public async Task<bool> CreateAsync(UserWorkoutProgramCreateDTO dto)
        {
            try
            {
                Console.WriteLine("▶ CreateAsync başladı:");
                Console.WriteLine($"➡ UserId: {dto.UserId}");
                Console.WriteLine($"➡ WorkoutProgramId: {dto.WorkoutProgramId}");

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
                if (user == null)
                {
                    Console.WriteLine("❌ Kullanıcı bulunamadı.");
                    return false;
                }

                var program = await _context.WorkoutPrograms.FindAsync(dto.WorkoutProgramId);
                if (program == null)
                {
                    Console.WriteLine("❌ Program bulunamadı.");
                    return false;
                }

                var alreadyExists = await _context.UserWorkoutPrograms.AnyAsync(x =>
                    x.UserId == dto.UserId && x.WorkoutProgramId == dto.WorkoutProgramId);
                if (alreadyExists)
                {
                    Console.WriteLine("❗ Bu kullanıcı zaten bu programa atanmış.");
                    return false;
                }

                var relation = new UserWorkoutProgram
                {
                    UserId = dto.UserId,
                    WorkoutProgramId = dto.WorkoutProgramId
                };

                _context.UserWorkoutPrograms.Add(relation);
                await _context.SaveChangesAsync();
                Console.WriteLine("✅ Kayıt başarıyla eklendi.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("💥 HATA OLUŞTU:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
