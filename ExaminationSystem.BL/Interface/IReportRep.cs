using ExaminationSystem.BL.ModelVM.ReportVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IReportRep
    {
        List<StudentInfo> GetStudentByDepartmentId(int id);
        List<st_getStudentGradesInAllCourses> GetStudentGradesInAllCourses(int id);
        List<st_getInstructorCoursesAndStudentsPerCourse> GetInstructorCoursesAndStudentsPerCourse(int id);
        List<st_showExamWithStudentAnswers> GetExamWithStudentAnswers(int examId, int stdId);
        List<Exam> GetAllExamStudent(int id);
    }
}
