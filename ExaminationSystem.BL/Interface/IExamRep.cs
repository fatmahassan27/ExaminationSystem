using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IExamRep
    {
        Exam? GetExamById(int id);
        string StoreStudentExamAnswers(int examId, string stdName, int? answer1, int? answer2, int? answer3,
        int? answer4, int? answer5, int? answer6, int? answer7, int? answer8, int? answer9, int? answer10);

        int CorrectExam(int examId, string stName);
    }
}
