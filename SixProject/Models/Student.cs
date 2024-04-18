using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name can't be blank"), StringLength(50), Display(Name = "Name:")]
        public string Name { get; set; } = default!;
        [ForeignKey("Department")]
        [Required(ErrorMessage ="Department must be selected"), StringLength(50), Display(Name="Department:")]
        public int DeptID { get; set; }
        [ForeignKey("Semester")]
        [Required(ErrorMessage ="Semester must be selected"), StringLength(50), Display(Name="Semester:")]
        public int SemesterId { get; set; }
        public string Mobile { get; set; } = default!;
        [EmailAddress]
        public string Email { get; set; } = default!;

        public virtual Department? Department { get; set; }
        public virtual Semester? Semester { get; set; }

    }
}
