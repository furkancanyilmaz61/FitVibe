using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitVibe.Data.Entities;

namespace FitVibe.Data.Context
{
    public class FitVibeDbContext : IdentityDbContext<ApplicationUser>
    {
        public FitVibeDbContext(DbContextOptions<FitVibeDbContext> options)
            : base(options) { }

        public DbSet<Coach> Coaches => Set<Coach>();
        public DbSet<WorkoutProgram> WorkoutPrograms => Set<WorkoutProgram>();
        public DbSet<UserWorkoutProgram> UserWorkoutPrograms => Set<UserWorkoutProgram>();
        public DbSet<DietPlan> DietPlans => Set<DietPlan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserWorkoutProgram>()
                .HasKey(x => new { x.UserId, x.WorkoutProgramId });

            modelBuilder.Entity<UserWorkoutProgram>()
                .HasOne(x => x.User)
                .WithMany(u => u.UserWorkoutPrograms)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWorkoutProgram>()
                .HasOne(x => x.WorkoutProgram)
                .WithMany(x => x.UserWorkoutPrograms)
                .HasForeignKey(x => x.WorkoutProgramId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
