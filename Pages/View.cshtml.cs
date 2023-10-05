using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repositories;
using System.Collections.Generic;

namespace WebApp.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IWorkoutRepository _workoutRepository;

        [BindProperty]
        public List<Workout> WorkoutList { get; set; }

        public ViewModel(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void OnGet()
        {
            WorkoutList = _workoutRepository.ReadWorkouts();
        }

        public IActionResult OnPostDelete(int Id)
        {
            Workout? itemToDelete = _workoutRepository.ReadWorkout(Id);

            if (itemToDelete == null)
            {
                return NotFound();
            }

            _workoutRepository.DeleteWorkout(itemToDelete);
            return RedirectToPage("/View");
        }
    }
}
