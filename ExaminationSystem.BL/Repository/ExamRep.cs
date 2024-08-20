using ExaminationSystem.BL.Interface;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExaminationSystem.BL.Repository
{
    public class ExamRep : IExamRep
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ExamRep(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public Exam? GetExamById(int id)
            => applicationDbContext.Exams
                .Include(e => e.Includes)
                .ThenInclude(i => i.Question)
                .ThenInclude(q => q.MultipleChoices)
                .FirstOrDefault(e => e.ExamId == id);

        public string StoreStudentExamAnswers(int examId, string stName, int? answer1, int? answer2,
            int? answer3, int? answer4, int? answer5, int? answer6, int? answer7, int? answer8,
            int? answer9, int? answer10)
            => applicationDbContext.Database.ExecuteSql(
                $"storeStudentExamAnswers @ex_id={examId}, @st_Name={stName}, @answer1={answer1}, @answer2={answer2}, @answer3={answer3}, @answer4={answer4}, @answer5={answer5}, @answer6={answer6}, @answer7={answer7}, @answer8={answer8}, @answer9={answer9}, @answer10={answer10}").ToString();

        public int CorrectExam(int examId, string stName)
            => applicationDbContext.Database.ExecuteSql(
                $"correctExam @exam_id={examId}, @student_name={stName}");

    }
}
