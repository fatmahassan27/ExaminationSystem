using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.ReportVM
{
    public record st_showExamWithStudentAnswers(Int64? Question, string? qs_title, string? Student_Answer, string? ModelAnswer, string? Student_name)
    {
    }
}
