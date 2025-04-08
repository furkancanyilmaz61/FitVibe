using FitVibe.Business.Operations.UserWorkoutProgram;
using FitVibe.Data.Entities;
using FitVibe.Business.Operations.User;


namespace FitVibe.Business.Services.Interfaces
{
    public interface IUserWorkoutProgramService
    {
        Task<List<UserWorkoutProgramDTO>> GetAllAsync();
        Task<bool> CreateAsync(UserWorkoutProgramCreateDTO dto);
    }
}