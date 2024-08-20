using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.ModelVM.ReportVM 
{
    public record StudentInfo(int studentId, string UserName, string emailAddress, string userFname, string userLname)
    {
    }
}
