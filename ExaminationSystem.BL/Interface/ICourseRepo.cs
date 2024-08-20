using ExaminationSystem.BL.ModelVM.Courses;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface ICourseRepo
    {
        List<GetALLCourseVM> GetAll();

        GetCourseByIDVM getCourseById(int id);

        void DeleteCourse(int CourseId);

        void EditCourse(int courseId, string courseName, int courseDuration);

        void EditCourse(EditCourseVM model);

        void InsertCourse(string courseName, int courseDuration);

        void InsertCourse(InsertIntoCourseVM model);

    }
}
