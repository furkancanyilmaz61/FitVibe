using System.Collections.Generic;

namespace FitVibe.Data.Entities
{
    public class WorkoutProgram
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int DurationInDays { get; set; }

        // Foreign key
        public int CoachId { get; set; }

        // Navigation property
        public Coach Coach { get; set; } = null!;

        // Many-to-many relation with User
        public ICollection<UserWorkoutProgram> UserWorkoutPrograms { get; set; } = new List<UserWorkoutProgram>();
    }
}
