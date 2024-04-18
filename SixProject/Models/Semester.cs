using System.ComponentModel.DataAnnotations;

namespace SixProject.Models
{
    public class Semester
    {
        public Semester()
        {
            this.Students = new List<Student>();
        }
        public int SemesterID { get; set; }
        [Required(ErrorMessage ="Semester Name can't be blank"), StringLength(20), Display(Name ="Semeseter Name")]
        public string SemesterName { get; set; } = default!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
