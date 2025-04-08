using FitVibe.Data.Entities;
using FitVibe.Business.Operations.WorkoutProgram;
public interface IWorkoutProgramService
{
    Task<List<WorkoutProgram>> GetAllAsync();
    Task<WorkoutProgram> GetByIdAsync(int id);
    Task<WorkoutProgram> CreateAsync(WorkoutProgramCreateDTO dto);
    Task<bool> UpdateAsync(WorkoutProgramUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}
