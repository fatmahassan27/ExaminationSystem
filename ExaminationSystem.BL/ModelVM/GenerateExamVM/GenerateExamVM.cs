using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.GenerateExamVM
{
    public class GenerateExamVM
    {
        [Key]
        public int CourseID { get; set; }

        public string TrueOrFalseCounnt { get; set; }
       
        public string OtherQuestionCount { get; set; }
        public List<StudentGenerateExamVM>? StId { get; set; }
    }
}
