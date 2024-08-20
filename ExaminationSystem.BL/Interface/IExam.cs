using ExaminationSystem.BL.ModelVM.ExamVM;
using ExaminationSystem.BL.ViewModels.ExamVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IExam
    {
        List<GetAllExamVM> GetAllExam();
        IEnumerable<GetExamByIdVM> GetExamById(int id);

        GetExamByIdVM getExamById(int id);
        void DeleteExam(int id);


    }
}
