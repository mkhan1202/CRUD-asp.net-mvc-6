using System.ComponentModel.DataAnnotations;

namespace SixProject.Models.ViewModels
{
    public class SemesterViewModel
    {
        public int SemesterID { get; set; }
        [Required(ErrorMessage = "Semester Name can't be blank"), StringLength(20), Display(Name = "Semeseter Name")]
        public string SemesterName { get; set; } = default!;
    }
}
