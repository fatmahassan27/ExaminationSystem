using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM.StudentVM;
using ExaminationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class StudentRepo:IStudentRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly StudentMapper _studentMapper;

        public StudentRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _studentMapper=new StudentMapper();
        }
        public List<GetAllStudentVM> getAllStudent()
        {
            var students = _applicationDbContext.Students.Include(a => a.Department).ToList();
            foreach (var item in students)
            {
                item.Stu = _applicationDbContext.Users.Where(user => user.UserId == item.StudentId).FirstOrDefault();
            }
            return _studentMapper.Mapp(students);

        }
        
        public GetStudentByIdVM GetStudentById(int? Id)
        {
            var students = _applicationDbContext.Students.Include(s => s.Department).Include(s => s.Stu).Include(s => s.Courses).Where(s => s.StudentId == Id).FirstOrDefault();
            return _studentMapper.Mapp(students);
        }
        public void DeleteStudentByID(int Id)
        {
            var Deleted = _applicationDbContext.Database.ExecuteSqlInterpolated($"Exec [st_deleteFromStudent] {Id}");
        }
        public void InsertStudent(InsertStudentVM insertStudentVM)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoUsers] {insertStudentVM.UserName},{insertStudentVM.UserFname},{insertStudentVM.UserLname},{insertStudentVM.EmailAddress},{insertStudentVM.Password},{2}");
            var Data = _applicationDbContext.Users.OrderByDescending(a => a.UserId).FirstOrDefault();
            _applicationDbContext.Database.ExecuteSql($"Exec  [st_insertIntoStudent] {Data.UserId},{insertStudentVM.StAddress},{insertStudentVM.DeptId},{insertStudentVM.StImg}");
        }
        public EditStudentVM GetStudentDataById(int Id)
        {
            var student = _applicationDbContext.Users.Where(a => a.UserId == Id).Include(a => a.Student).ThenInclude(a => a.Department).FirstOrDefault();
            return new EditStudentVM() { EmailAddress = student.EmailAddress, UserFname = student.UserFirstName, UserLname = student.UserLastName, Password = student.Password, StId = student.UserId, StImg = student.Student.StudentImg, StAddress = student.Student.StudentAddress, DeptId = student.Student.DepartmenttId };
        }
        public void Edit(EditStudentVM editStudentVM)
        {
            if (editStudentVM.Image == null)
                editStudentVM.StImg = _applicationDbContext.Students.Where(a => a.StudentId == editStudentVM.StId).FirstOrDefault().StudentImg;
            else
                //editStudentVM.StImg = FileUploader.UploadFile("Imgs", editStudentVM.Image);
            _applicationDbContext.Database.ExecuteSql($"Exec [st_updateStudent]{editStudentVM.StId}, {editStudentVM.StAddress},{editStudentVM.DeptId},{editStudentVM.StImg}");
           _applicationDbContext.Database.ExecuteSql($"Exec [st_updateUsers] {editStudentVM.StId} ,{editStudentVM.UserFname},{editStudentVM.UserLname},{editStudentVM.EmailAddress},{editStudentVM.Password}");
        }
    }
}
