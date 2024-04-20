using System.ComponentModel.DataAnnotations;

namespace SixProject.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Department name can't be blank"), StringLength(50), Display(Name = "Department Name:")]
        public string DepartmentName { get; set; } = default!;
        
    }
}
