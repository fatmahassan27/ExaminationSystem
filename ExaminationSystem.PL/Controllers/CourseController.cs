using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ExaminationSystem.PL.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;
        public CourseController(ICourseRepo _courseRepo)
        {
            courseRepo = _courseRepo;
        }
        public IActionResult GetAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Course = courseRepo.GetAll();
                return View(Course);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult DeleteCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                courseRepo.DeleteCourse(id);
                return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");
        }



        public IActionResult EditCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = courseRepo.getCourseById(id);
                EditCourseVM EditCourseVM = new EditCourseVM()
                {
                    CourseId = Data.CourseId,
                    CourseHours = (int)Data.CourseHours,
                    CourseName = Data.CourseName,
                };
                return View(EditCourseVM);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult EditCourse(EditCourseVM editCourseVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {

                if (ModelState.IsValid)
                {
                    courseRepo.EditCourse(editCourseVM);
                    return RedirectToAction("getAll");
                }
                return View(editCourseVM);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult InsertCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult InsertCourse(InsertIntoCourseVM InsertCourseVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {

                if (ModelState.IsValid)
                {
                    courseRepo.InsertCourse(InsertCourseVM);
                    return RedirectToAction("getAll");
                }
                return View(InsertCourseVM);
            }
            return RedirectToAction("Login", "Account");

        }

    }
}

