using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using WebApp.Model;
using WebApp.Repositories;
using System.IO;

namespace WebApp.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IWorkoutRepository _workoutRepository;
        [BindProperty]
        public Workout Workout { get; set; }
        [BindProperty]
        public IFormFile? PhotoFile { get; set; }

        public UpdateModel(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void OnGet(int Id)
        {
            Workout = _workoutRepository.ReadWorkout(Id);
        }

        public IActionResult OnPost(int Id)
        {
            Workout itemToUpdate = _workoutRepository.ReadWorkout(Id);
            itemToUpdate.Name = Workout.Name;
            itemToUpdate.Type = Workout.Type;
            itemToUpdate.Description = Workout.Description;
            if (PhotoFile != null)
            {
                using MemoryStream ms = new MemoryStream();
                PhotoFile.CopyTo(ms);
                itemToUpdate!.Image = ms.ToArray();
            }
            _workoutRepository.UpdateWorkout(itemToUpdate);
            return RedirectToPage("/View");
        }
    }
}
