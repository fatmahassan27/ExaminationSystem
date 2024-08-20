using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.StudentResultVM;
using ExaminationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class GetExamResultRepo:IGetResultRepo
    {
        private readonly ApplicationDbContext Db;
        public GetExamResultRepo(ApplicationDbContext _Db)
        {
            this.Db = _Db;
        }

        public StudentResultVM Get(int examID, int? studentID)
        {
            var studentResultVM = new StudentResultVM();
            studentResultVM.student = Db.Students.Include(a => a.Stu).Where(student => student.StudentId == studentID).FirstOrDefault();
            var Exam = Db.Exams.Where(a => a.ExamId == examID).FirstOrDefault();
            studentResultVM.ExamName = Exam.ExamName;
            studentResultVM.FinalDegree = Exam.ExamFinalGrade;
            return studentResultVM;

        }

    }
}
