using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.DepartmentVM
{
    public class DepartmentVM
    {
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(10, MinimumLength = 2,
            ErrorMessage = "Department Name must be between 2 and 10 characters")]
        public string? DeptName { get; set; }

        [Required(ErrorMessage = "Department Description is required")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Department Description must be between 2 and 50 characters")]
        public string? DeptDesc { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    }
}
