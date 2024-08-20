using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.Courses;
using ExaminationSystem.BL.ModelVM.ExamVM;
using ExaminationSystem.BL.Repository;
using ExaminationSystem.BL.ViewModels.ExamVM;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExam exam;
        public ExamController(IExam _exam)
        {
            exam = _exam;
        }
        public IActionResult GetAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleId = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleId == 1)
            {
                var Data = exam.GetAllExam();
                return View(Data);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult getExamById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var data = exam.GetExamById(id);
                return View(data);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult DeleteExam(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleId = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleId == 1)
            {
                exam.DeleteExam(id);

                return RedirectToAction("GetAll"); ;
            }

            return RedirectToAction("Login", "Account");
        }


    }
}
