using ExaminationSystem.BL.ModelVM.StudentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IStudentRepo
    {
       public List<GetAllStudentVM> getAllStudent();


        public void DeleteStudentByID(int Id);
        public void InsertStudent(InsertStudentVM insertStudentVM);
        public void Edit(EditStudentVM editStudentVM);
        public GetStudentByIdVM GetStudentById(int? Id);
        public EditStudentVM GetStudentDataById(int id);

    }
}
