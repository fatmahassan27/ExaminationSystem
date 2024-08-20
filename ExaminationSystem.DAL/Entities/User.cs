using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.DAL.Entities
{
   public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(20),Required]
        public string UserName { get; set; }

        [MaxLength(20)]
        public string? UserFirstName { get; set; }
        [MaxLength(20)]
        public string? UserLastName { get; set; }
        [Required, MaxLength(50)]
        public string EmailAddress { get; set; }
        
        [Required, MaxLength(50)]
        public string Password { get; set; }
        
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        //Navigation 

        public virtual Role? Role { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Instructor? Instructor { get; set; }



    }
}
