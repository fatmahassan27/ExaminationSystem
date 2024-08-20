using ExaminationSystem.BL.ModelVM.InstructorVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public  interface IInstructorRepo
    {
       public  List<GetAllInstructorVM> getAllInstructor();

        public void DeleteInstructorByID(int Id);
        public void InsertInstructor(InsertInstructorVM instructorVM);
       public void Edit(EditInstractorVM editInstractorVM);
        public GetInstructorByIdVM GetInstructorById(int id);
         public EditInstractorVM GetInstructorDataById(int id);
    }
}
