
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitVibe.Data.Entities
{
    public class UserWorkoutProgram
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Key, Column(Order = 1)]
        public int WorkoutProgramId { get; set; }
        public WorkoutProgram WorkoutProgram { get; set; }
    }
}
