using ExaminationSystem.BL.ModelVM.GenerateExamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IGenerateExamRepo
    {
        void Generate(GenerateExamVM generateExam);

        GenerateExamVM Get(int id);
    }
}
