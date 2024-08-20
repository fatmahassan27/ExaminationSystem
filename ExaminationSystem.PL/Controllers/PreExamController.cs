using ExaminationSystem.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class PreExamController : Controller
    {
        readonly IPreExamRepo preExam;
        int? UserId;
        int? RoleID;
        public PreExamController(IPreExamRepo _preExam)
        {
            preExam = _preExam;
        }

        public IActionResult StudentProfile()
        {
            UserId = HttpContext.Session.GetInt32("UserId");
            RoleID = HttpContext.Session.GetInt32("RoleId");

            var Exam = preExam.GetExamByStudentId(UserId);

            if (UserId != null && RoleID != null && RoleID == 2)
            {
                var student = preExam.GetStudentById(UserId);
                var studentExams = preExam.GetExamList(UserId);
                ViewBag.Exams = studentExams;
                return View("StudentProfile", student);
            }
            return RedirectToAction("Login", "Account", Exam);
        }

        public bool CheckExam() => preExam.GetExamByStudentId(UserId) is null;

        public IActionResult CheckIfStudentHasExam()
        {
            if (CheckExam())
            {
                return View("ExamDisabled");
            }

            return RedirectToAction(nameof(StudentProfile));
        }

    }
}
