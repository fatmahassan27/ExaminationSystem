using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.InstructorVM
{
    public class EditInstractorVM
    {
        public int InsId { get; set; }
        [Required]
        public string InsDegree { get; set; }
        [Required(ErrorMessage = "Degree is Required")]

        public int InsSalary { get; set; }
        [Required(ErrorMessage = "UserFname is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserFname { get; set; }
        [Required(ErrorMessage = "UserLname is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserLname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Password { get; set; }
    }
}
