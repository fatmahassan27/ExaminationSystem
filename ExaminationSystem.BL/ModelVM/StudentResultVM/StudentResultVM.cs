using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.StudentResultVM
{
    public class StudentResultVM
    {
        public string ExamName { get; set; }
        public decimal? FinalDegree { get; set; }
        public Student student { get; set; }
    }
}
