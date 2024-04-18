using Microsoft.EntityFrameworkCore;
using SixProject.Models;

namespace SixProject.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
