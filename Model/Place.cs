using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa treningu")]
        public string? Name { get; set; }

        [Display(Name = "Serie x Czas trwania")]
        public string? Type { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Display(Name = "Obrazek")]
        public byte[]? Image { get; set; }
    }
}
