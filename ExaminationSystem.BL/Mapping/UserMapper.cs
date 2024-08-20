using ExaminationSystem.BL.ModelVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
    public class UserMapper
    {
        public UserVM Mapping(User user)
        {
            var userVM = new UserVM
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
            };
            return userVM;
        }
    }
}
