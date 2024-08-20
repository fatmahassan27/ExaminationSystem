using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(20)]
        public string? RoleName { get; set; }

        [MaxLength(50)]
        public string? RoleDesc { get; set; }
        public virtual ICollection<User> Users { get; set; }=new HashSet<User>();

    }
}
