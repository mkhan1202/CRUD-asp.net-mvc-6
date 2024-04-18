namespace SixProject.Models
{
    public class Department
    {
        public Department()
        {
            this.Students = new List<Student>();
        }
        public int DepartmentID { get; set; }
        public string MyProperty { get; set; } = default!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
