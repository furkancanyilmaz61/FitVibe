using FitVibe.Data.Entities;

public class Coach
{
    public int Id { get; set; }
    public string FullName { get; set; }

    // Bu listeyi mutlaka başlat
    public ICollection<WorkoutProgram> WorkoutPrograms { get; set; } = new List<WorkoutProgram>();
}
