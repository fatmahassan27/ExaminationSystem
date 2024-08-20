using ExaminationSystem.BL.Interface;
using ExaminationSystem.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class CurrentExamController : Controller
    {

        private readonly IExamRep _examRep;
        private readonly IStudentRepo _studentRepo;

        public CurrentExamController(IExamRep examRep, IStudentRepo studentRepo)
        {
            _examRep = examRep;
            _studentRepo = studentRepo;
        }

        public IActionResult Index(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 2)
            {
                var exam = _examRep.GetExamById(id);
                if (exam is null)
                    return NotFound();

                return View(exam);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult Index(Exam exam)
        {
              int? userId = HttpContext.Session.GetInt32("UserId");
            int? roleID = HttpContext.Session.GetInt32("RoleId");
            if (userId != null && roleID == 2)
            {
                var student = _studentRepo.GetStudentById(userId);
                try
                {
                    List<int?> answers = [null, null, null, null, null, null, null, null, null, null];
                    var count = 0;
                    foreach (var include in exam.Includes)
                    {
                        if (include.StudentAnswer is not null)
                            answers[count] = include.StudentAnswer;
                        count++;
                    }

                    _examRep.StoreStudentExamAnswers(exam.ExamId, $"{student.UserFname} {student.UserLname}", answers[0], answers[1],
                        answers[2], answers[3], answers[4], answers[5], answers[6], answers[7], answers[8],
                        answers[9]);

                    _examRep.CorrectExam(exam.ExamId, student.UserName);
                }
                catch (Exception e)
                {
                    Exam? showedExam = _examRep.GetExamById(exam.ExamId);
                    return View(showedExam);
                }

                return RedirectToAction("Index", "Result", new { id = exam.ExamId });
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
