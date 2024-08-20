using ExaminationSystem.BL.ModelVM.StudentResultVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IGetResultRepo
    {
        StudentResultVM Get(int examID, int? studentID);
    }
}
