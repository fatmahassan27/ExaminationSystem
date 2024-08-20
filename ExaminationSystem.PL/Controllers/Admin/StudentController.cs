using ExaminationSystem.BL;
using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.StudentVM;

using ExaminationSystem.BL.Repository;
using ExaminationSystem.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ExaminationSystem.PL.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IDepartmentRepo departmentRepo;
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentController(IStudentRepo studentRepo, ApplicationDbContext applicationDbContext)
        {
            _studentRepo = studentRepo;
            _applicationDbContext = new ApplicationDbContext();
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = _studentRepo.getAllStudent();
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult getById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = _studentRepo.GetStudentById(id);
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult DeleteStudentByID(int Id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                _studentRepo.DeleteStudentByID(Id);
                return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult InsertStudent()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {

                ViewData["Department"] = new SelectList(_applicationDbContext.Departments.ToList(), "DepartmentId", "DepartmentName");

                return View();
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult InsertStudent(InsertStudentVM insertStudentVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (ModelState.IsValid)
                {
                    insertStudentVM.StImg = UploadImage.Upload("Images", insertStudentVM.Image);

                    _studentRepo.InsertStudent(insertStudentVM);
                    return RedirectToAction("getAll");
                }
                ViewData["Department"] = new SelectList(_applicationDbContext.Departments.ToList(), "DepartmentId", "DepartmentName");

                return View(insertStudentVM);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult Edit(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                ViewData["Department"] = new SelectList(_applicationDbContext.Departments.ToList(), "DepartmentId", "DepartmentName");

                var Data = _studentRepo.GetStudentDataById(id);
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult Edit(EditStudentVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (ModelState.IsValid)
                {
                    model.StImg = UploadImage.Upload("Images", model.Image);
                    _studentRepo.Edit(model);
                    return RedirectToAction("getAll");

                }

                ViewData["Department"] = new SelectList(_applicationDbContext.Departments.ToList(), "DepartmentId", "DepartmentName");
                return View(model);
            }
            return RedirectToAction("Login", "Account");

        }
    }


}

