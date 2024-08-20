using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Exam
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ExamId { get; set; }
        [MaxLength(20)]

        public string? ExamName { get; set; }
        public int? ExamFinalGrade { get; set; }

        public int? StudentId { get; set; }
        public virtual Student? Student { get; set; }

        public virtual ICollection<Include> Includes { get; set; } = new List<Include>();

    }
}
