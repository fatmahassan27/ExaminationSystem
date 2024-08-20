using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.GenerateExamVM
{
    public class StudentGenerateExamVM
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public bool IsSelected { get; set; }
    }
}
