using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.ReportVM;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class ReportRep :IReportRep
    {
        private readonly ApplicationDbContext dbContext;
        public ReportRep(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Exam> GetAllExamStudent(int stid)
        {
            var data = dbContext.Exams.Where(a => a.StudentId == stid).ToList();
            return data;
        }

        public List<st_showExamWithStudentAnswers> GetExamWithStudentAnswers(int examId, int stdId)
        {
            var data = dbContext.Database.SqlQuery<st_showExamWithStudentAnswers>($"Exec [GetExamwithAnswer] {examId},{stdId}").ToList();
            return data;
        }

        public List<st_getInstructorCoursesAndStudentsPerCourse> GetInstructorCoursesAndStudentsPerCourse(int id)
        {
            var data = dbContext.Database.SqlQuery<st_getInstructorCoursesAndStudentsPerCourse>($"Exec  [GetInstructorCourseAndStudentPerCourse ] {id}").ToList();
            return data;
        }

        public List<StudentInfo> GetStudentByDepartmentId(int id)
        {
            var data = dbContext.Database.SqlQuery<StudentInfo>($"Exec [GetStudentinfoByDeptId]{id}").ToList();
            return data;
        }

        public List<st_getStudentGradesInAllCourses> GetStudentGradesInAllCourses(int id)
        {
            var data = dbContext.Database.SqlQuery<st_getStudentGradesInAllCourses>($"Exec  [GetStudentGradeInAllCouses] {id} ").ToList();
            return data;
        }
    }
}
