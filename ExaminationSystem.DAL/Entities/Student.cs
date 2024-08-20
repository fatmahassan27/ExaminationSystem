using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(50)]
        public string? StudentAddress { get; set; }
        public string? StudentImg { get; set; }
        [ForeignKey("Department")]
         public int? DepartmenttId { get; set; }

        //navigation 

        public virtual User Stu { get; set; } = null!;
        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();


    }
}
