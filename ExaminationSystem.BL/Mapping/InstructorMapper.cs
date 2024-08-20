using ExaminationSystem.BL.ModelVM.InstructorVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
   public class InstructorMapper
    {
        public List<GetAllInstructorVM> Mapp(List<Instructor> instructors)
        {
            List<GetAllInstructorVM> getAllInstructors = new List<GetAllInstructorVM>();
            foreach (Instructor instructor in instructors)
            {
                getAllInstructors.Add(new GetAllInstructorVM { InsId = instructor.InstructorId, UserName = instructor.User.UserName, UserFname = instructor.User.UserFirstName, InsDegree = instructor.InstructorDegree, UserLname = instructor.User.UserLastName, InsSalary = instructor.InstructorSalary });
            }
            return getAllInstructors;
        }
        public GetInstructorByIdVM Mapp(Instructor instructor)
        {
            GetInstructorByIdVM getInstructorById = new GetInstructorByIdVM() { InsId = instructor.InstructorId, UserName = instructor.User.UserName, UserFname = instructor.User.UserFirstName, InsDegree = instructor.InstructorDegree, UserLname = instructor.User.UserLastName, InsSalary = instructor.InstructorSalary, Departments = instructor.Departments };
            return getInstructorById;
        }
        public InsertInstructorVM Map(InsertInstructorVM insertInstructorVM)
        {
            InsertInstructorVM insertInstructor = new InsertInstructorVM() { UserName = insertInstructorVM.UserName, UserFname = insertInstructorVM.UserFname, UserLname = insertInstructorVM.UserLname, EmailAddress = insertInstructorVM.EmailAddress, Password = insertInstructorVM.Password, InsDegree = insertInstructorVM.InsDegree, InsSalary = insertInstructorVM.InsSalary };
            return insertInstructor;
        }
    }
}
