using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ViewModels.ExamVM
{
    public class GetAllExamVM
    {
        public int ExamId { get; set; }
        
        public string ExamName { get; set; }
        public int? ExamFinalGrade { get; set; }

        public int ? StudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}
