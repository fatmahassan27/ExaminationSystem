using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Question
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int QuestionId { get; set;}
        public string QuestionType { get; set; }
        public string? QuestionTitle { get; set; }
        public int QuestionGrade { get; set; }
        public int? QuestionModelAnswer { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public virtual ICollection<Include> Includes { get; set; } = new List<Include>();

        public virtual ICollection<MultipleChoice> MultipleChoices { get; set; } = new List<MultipleChoice>();


    }
}
