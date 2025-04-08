namespace FitVibe.Business.Operations.WorkoutProgram
{
    public class WorkoutProgramUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int DurationInDays { get; set; }
        public int CoachId { get; set; }
    }
}
