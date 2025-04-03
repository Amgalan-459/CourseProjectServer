using CourseProjectServer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProjectServer.Data.Context {
    public class CourseDbContext : DbContext {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public CourseDbContext (DbContextOptions options) : base(options) {
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\.;Initial Catalog=course;Integrated Security=True");
        }
    }
}
