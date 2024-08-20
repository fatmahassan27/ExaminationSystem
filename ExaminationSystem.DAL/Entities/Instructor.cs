using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        [MaxLength(20)]
        public string? InstructorDegree { get; set; }

        public int? InstructorSalary { get; set; }

        public virtual User? User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();


    }
}
