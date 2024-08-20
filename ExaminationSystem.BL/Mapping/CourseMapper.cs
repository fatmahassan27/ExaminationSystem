using ExaminationSystem.BL.ModelVM.Courses;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
    public class CourseMapper
    {
        public List<GetALLCourseVM> Map(List<Course> courses)
        {
            List<GetALLCourseVM> getAllCoursesVM = new List<GetALLCourseVM>();
            foreach (Course course in courses)
            {
                getAllCoursesVM.Add(new GetALLCourseVM() { CourseId = course.CourseId, CourseHours = course.CourseHours, CourseName = course.CourseName , Ins= course.Instructors});
            }
            return getAllCoursesVM;
        }

        public GetCourseByIDVM Map(Course course)
        {
           
            GetCourseByIDVM getCourseByIDVM = new GetCourseByIDVM();    

            getCourseByIDVM.CourseId = course.CourseId;

            getCourseByIDVM.CourseName= course.CourseName;

            getCourseByIDVM.CourseHours=course.CourseHours;

            return getCourseByIDVM;
        }

    }

   

}
