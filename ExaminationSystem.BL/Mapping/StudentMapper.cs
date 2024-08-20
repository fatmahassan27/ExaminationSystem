using ExaminationSystem.BL.ModelVM.StudentVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
    public class StudentMapper
    {
        public List<GetAllStudentVM> Mapp(List<Student> students)
        {
            List<GetAllStudentVM> getAllStudentVMs = new List<GetAllStudentVM>();
            foreach (Student student in students)
            {
                getAllStudentVMs.Add(new GetAllStudentVM { StId = student.StudentId, UserLname = student.Stu.UserLastName, UserFname = student.Stu.UserFirstName, StAddress = student.StudentAddress, StImg = student.StudentImg, Dept = student.Department, UserName = student.Stu.UserName });
            }
            return getAllStudentVMs;
        }
        public GetStudentByIdVM Mapp(Student student)
        {
            GetStudentByIdVM getStudentByIdVM = new GetStudentByIdVM() { courses = student.Courses, Email = student.Stu.EmailAddress, UserLname = student.Stu.UserLastName, UserFname = student.Stu.UserFirstName, StAddress = student.StudentAddress, StImg = student.StudentImg, Dept = student.Department, UserName = student.Stu.UserName };
            return getStudentByIdVM;
        }
        public InsertStudentVM Map(InsertStudentVM insertStudentVM)
        {
            InsertStudentVM insertStudent = new InsertStudentVM() { UserName = insertStudentVM.UserName, UserFname = insertStudentVM.UserFname, UserLname = insertStudentVM.UserLname, EmailAddress = insertStudentVM.EmailAddress, Password = insertStudentVM.Password, DeptId = insertStudentVM.DeptId, StAddress = insertStudentVM.StAddress };
            return insertStudent;
        }
    }
}
