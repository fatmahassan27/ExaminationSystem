using ExaminationSystem.BL.ModelVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface ILoginRepo
    {
        UserVM IsValid(LoginVM loginVM);
    }
}
