using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM
{
    public class PreExamVM
    {

        public int StudentId { get; set; }

        public int? DepartmenttId { get; set; }

        public string? StudentImg { get; set; }

        public string? StudentAddress { get; set; }

        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

        public virtual User St { get; set; } = null!;

        public virtual ICollection<Course> Crs { get; set; } = new List<Course>();

    }
}
