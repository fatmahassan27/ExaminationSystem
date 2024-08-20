using ExaminationSystem.BL.ViewModels.ExamVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
    public class ExamMapper
    {
        public List<GetAllExamVM> Map(List<Exam> exams)
        {

            List<GetAllExamVM> getAllExams = new List<GetAllExamVM>();

            foreach (var item in exams)
            {
                getAllExams.Add(new GetAllExamVM() { ExamId = item.ExamId, ExamName = item.ExamName, ExamFinalGrade = item.ExamFinalGrade,StudentId=item.StudentId, Student = item.Student });
            }

            return getAllExams;

        }

        public IEnumerable<GetExamByIdVM> Map(IEnumerable<Include> exam)
        {
            List<GetExamByIdVM> getExamByIdVM = new List<GetExamByIdVM>();
            foreach (var item in exam)
            {
                getExamByIdVM.Add(new GetExamByIdVM() { _questions = item.Question, studentAnswer = item.StudentAnswer });
            }
            return getExamByIdVM;

        }

        public GetExamByIdVM Map(Exam exam)
        {
           GetExamByIdVM getExamByIdVM = new GetExamByIdVM ();
           
            getExamByIdVM.ExamId=exam.ExamId;

            getExamByIdVM.ExamName= exam.ExamName;

            getExamByIdVM.ExamFinalGrade=exam.ExamFinalGrade;

            getExamByIdVM.StudentId = exam.StudentId;

            return getExamByIdVM;

        }

    }
}
