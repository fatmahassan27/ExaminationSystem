using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IPreExamRepo
    {
        Exam GetExamByStudentId(int? StudentId);
        Student GetStudentById(int? StudentId);

        Exam GetExamByStudentId(int id);

        List<Exam> GetExamList(int? StudentId);
    }
}
