using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Repositories
{
    public interface IWorkoutRepository
    {
        // Create
        bool CreateWorkout(Workout entity);

        // ReadAll
        List<Workout> ReadWorkouts();

        // Read
        Workout ReadWorkout(int id);

        // Update
        bool UpdateWorkout(Workout entity);

        // Delete
        bool DeleteWorkout(Workout entity);
    }
}
