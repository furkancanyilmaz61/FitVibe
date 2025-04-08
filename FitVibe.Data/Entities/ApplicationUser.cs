using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitVibe.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public ICollection<UserWorkoutProgram> UserWorkoutPrograms { get; set; } = new List<UserWorkoutProgram>();
        public ICollection<DietPlan> DietPlans { get; set; } = new List<DietPlan>();
    }
}
