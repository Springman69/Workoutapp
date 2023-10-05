using Microsoft.EntityFrameworkCore;
using WebApp.Repositories;

namespace WebApp.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(WorkoutRepository.connectionString);
        }
    }
}
