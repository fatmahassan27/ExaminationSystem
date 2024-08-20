using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public  class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int CourseHours { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
