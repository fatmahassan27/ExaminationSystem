using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM.InstructorVM;
using ExaminationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public  class InstructorRepo:IInstructorRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly InstructorMapper _instructorMapper;

       public InstructorRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _instructorMapper = new InstructorMapper();
        }
        public List<GetAllInstructorVM> getAllInstructor()
        {
            var instructor = _applicationDbContext.Instructors.Include(a=>a.User).ToList();
            return _instructorMapper.Mapp(instructor);

        }

        public void DeleteInstructorByID(int Id)
        {
            var Deleted = _applicationDbContext.Database.ExecuteSqlInterpolated($"Exec [st_deleteFromInstructor] {Id}");

        }
        public void InsertInstructor(InsertInstructorVM instructorVM)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoUsers] {instructorVM.UserName},{instructorVM.UserFname},{instructorVM.UserLname},{instructorVM.EmailAddress},{instructorVM.Password},{1}");
            var Data = _applicationDbContext.Users.OrderByDescending(a => a.UserId).FirstOrDefault();
            _applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoInstructor] {Data.UserId},{instructorVM.InsDegree}, {instructorVM.InsSalary}");
        }
        public void Edit(EditInstractorVM editInstractorVM)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_updateInstructor] {editInstractorVM.InsId},{editInstractorVM.InsDegree},{editInstractorVM.InsSalary}");
            _applicationDbContext.Database.ExecuteSql($"Exec [st_updateUsers] {editInstractorVM.InsId} ,{editInstractorVM.UserFname},{editInstractorVM.UserLname},{editInstractorVM.Email},{editInstractorVM.Password}");
        }
        public GetInstructorByIdVM GetInstructorById(int Id)
        {
            var instructor = _applicationDbContext.Instructors.Where(a => a.InstructorId == Id).Include(a => a.Departments).FirstOrDefault();
            instructor.User = _applicationDbContext.Users.Where(user => user.UserId == instructor.InstructorId).FirstOrDefault();
            return _instructorMapper.Mapp(instructor);
        }
        public EditInstractorVM GetInstructorDataById(int Id)
        {
            var instructor = _applicationDbContext.Users.Where(a => a.UserId == Id).Include(a => a.Instructor).FirstOrDefault();
            return new EditInstractorVM() { Email = instructor.EmailAddress, InsDegree = instructor.Instructor.InstructorDegree, Password = instructor.Password, UserFname = instructor.UserFirstName, UserLname = instructor.UserLastName, InsId = instructor.UserId, InsSalary = (int)instructor.Instructor.InstructorSalary };
        }
    }
}
