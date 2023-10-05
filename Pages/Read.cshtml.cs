using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Pages
{
    public class ReadModel : PageModel
    {
        private readonly IWorkoutRepository _workoutRepository;

        [BindProperty]
        public Workout Workout { get; set; }

        public ReadModel(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void OnGet(int Id)
        {
            Workout = _workoutRepository.ReadWorkout(Id);
        }
    }
}
