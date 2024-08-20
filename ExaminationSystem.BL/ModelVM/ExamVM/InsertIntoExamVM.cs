using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.ExamVM
{
    public class InsertIntoExamVM
    {
        public int ExamId { get; set; }

        public string ExamName { get; set; }
        public int? ExamFinalGrade { get; set; }

        public int ? StudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}
