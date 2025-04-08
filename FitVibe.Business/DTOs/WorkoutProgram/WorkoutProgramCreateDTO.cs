public class WorkoutProgramCreateDTO
{
    public string UserId { get; set; }              
    public int WorkoutProgramId { get; set; }
   
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationInDays { get; set; }
    public int CoachId { get; set; }
}
