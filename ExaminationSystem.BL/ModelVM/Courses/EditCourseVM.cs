using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.Courses
{
    public class EditCourseVM
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseHours { get; set; }
    }
}
