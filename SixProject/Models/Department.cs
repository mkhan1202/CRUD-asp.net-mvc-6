using System.ComponentModel.DataAnnotations;

namespace SixProject.Models
{
    public class Department
    {
        public Department()
        {
            this.Students = new List<Student>();
        }
        public int DepartmentID { get; set; }
        [Required(ErrorMessage ="Department name can't be blank"), StringLength(50), Display(Name ="Department Name:")]
        public string DepartmentName { get; set; } = default!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
