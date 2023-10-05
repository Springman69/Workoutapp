using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IWorkoutRepository _workoutRepository;

        [BindProperty]
        public Workout Workout { get; set; }

        [BindProperty]
        public IFormFile? PhotoFile { get; set; }

        public CreateModel(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (PhotoFile != null)
            {
                using MemoryStream ms = new MemoryStream();
                PhotoFile.CopyTo(ms);
                Workout.Image = ms.ToArray();
            }

            _workoutRepository.CreateWorkout(Workout);
            return RedirectToPage("/View");
        }
    }
}
