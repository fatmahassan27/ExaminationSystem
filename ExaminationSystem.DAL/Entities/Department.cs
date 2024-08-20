using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [MaxLength(20)]
        public string? DepartmentName { get; set; }
        [MaxLength(50)]
        public string? DepartmentDesc { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

        public virtual  ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
