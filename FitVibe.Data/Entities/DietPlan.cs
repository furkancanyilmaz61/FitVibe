using System.ComponentModel.DataAnnotations;
using FitVibe.Data.Entities;


namespace FitVibe.Data.Entities
{
    public class DietPlan
    {
        [Key]
        public int Id { get; set; }

        public string MealName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Calories { get; set; }

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
