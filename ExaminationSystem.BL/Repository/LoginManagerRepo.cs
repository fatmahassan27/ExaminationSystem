using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class LoginManagerRepo : ILoginRepo
    {
        private readonly ApplicationDbContext _context;
        private UserMapper userMapper;
        public LoginManagerRepo(ApplicationDbContext context)
        {
            _context = context;
            userMapper = new UserMapper();
        }

        public User CheckIfUserFound(string username)
        {
            var user = new User();
            user = _context.Users.Where(x => x.UserName == username).Include(a => a.Role).FirstOrDefault();
            return user;
        }
        public UserVM IsValid(LoginVM loginVM)
        {
            var user = CheckIfUserFound(loginVM.UserName);
            if (user != null)
            {
                if (user.Password == loginVM.Password)
                    return userMapper.Mapping(user);
            }
            return null;

        }
    }
}

