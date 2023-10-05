using WebApp.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApp.Repositories
{
    internal class WorkoutRepository : IWorkoutRepository
    {
        private static string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workouts.db");
        public static string connectionString = $"Data Source={dbFilePath}";
        private AppDbContext _appDbContext = new AppDbContext();

        public WorkoutRepository()
        {
            _appDbContext.Database.EnsureCreated();
        }

        // Create method
        public bool CreateWorkout(Workout entity)
        {
            bool isCreated = false;
            _appDbContext.Add(entity);
            if (_appDbContext.SaveChanges() == 1)
            {
                isCreated = true;
            }
            return isCreated;
        }

        // ReadAll method
        public List<Workout> ReadWorkouts()
        {
            return _appDbContext.Workouts.ToList();
        }

        // Read method
        public Workout ReadWorkout(int id)
        {
            return _appDbContext.Workouts.Find(id) ?? new Workout();
        }

        // Update method
        public bool UpdateWorkout(Workout entity)
        {
            bool isUpdated = false;
            _appDbContext.Update(entity);
            if (_appDbContext.SaveChanges() == 1)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        // Delete method
        public bool DeleteWorkout(Workout entity)
        {
            bool isDeleted = false;
            _appDbContext.Remove(entity);
            if (_appDbContext.SaveChanges() == 1)
            {
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
