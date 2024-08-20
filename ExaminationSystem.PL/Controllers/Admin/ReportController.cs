using ExaminationSystem.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers.Admin
{
    public class ReportController : Controller
    {
       
            private readonly IStudentRepo studentRepo;
            private readonly ICourseRepo courseRepo;
            private readonly IReportRep Report;
            private readonly IDepartmentRepo Department;
            private readonly IExamRep examRep;
            private readonly IExam exam;
            private readonly IInstructorRepo InstructorRepo;

            public ReportController(IStudentRepo _studentRepo, ICourseRepo _courseRepo, IReportRep _report, IInstructorRepo _InstructorRepo, IDepartmentRepo _department, IExamRep _examRepo, IExam _exam)
            {
                studentRepo = _studentRepo;
                courseRepo = _courseRepo;
                Report = _report;
                InstructorRepo = _InstructorRepo;
                Department = _department;
                exam = _exam;
                examRep = _examRepo;
            }
            public IActionResult Index()

            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                int? roleId = HttpContext.Session.GetInt32("RoleId");
                if (userId != null && roleId == 1)
                {
                    ViewBag.AllDepartment = Department.GetAllDepartments();
                    ViewBag.AllExam = exam.GetAllExam();
                    ViewBag.AllInstractor = InstructorRepo.getAllInstructor();
                    ViewBag.AllStudent = studentRepo.getAllStudent();
                    ViewBag.AllCourse = courseRepo.GetAll();
                    return View();
                }
                return RedirectToAction("Login", "Account");
            }
            [HttpGet]

            public IActionResult StudentInfo(int id)
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                int? roleId = HttpContext.Session.GetInt32("RoleId");
                if (userId != null && roleId == 1)
                {
                    var data = Report.GetStudentByDepartmentId(id);
                    return View(data);
                }
                return RedirectToAction("Login", "Account");
            }
            public IActionResult ExamQuestion(int id)
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                int? roleId = HttpContext.Session.GetInt32("RoleId");
                if (userId != null && roleId == 1)
                {
                    var Data = examRep.GetExamById(id);
                    return View(Data);
                }
                return RedirectToAction("Login", "Account");

            }

            [HttpGet]
            public IActionResult StudentCourse(int id)
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                int? roleId = HttpContext.Session.GetInt32("RoleId");
                if (userId != null && roleId == 1)
                {
                    var data = Report.GetInstructorCoursesAndStudentsPerCourse(id);
                    return View(data);
                }
                return RedirectToAction("Login", "Account");

            }
            [HttpGet]
            public IActionResult StudentGrade(int id)
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                int? roleId = HttpContext.Session.GetInt32("RoleId");
                if (userId != null && roleId == 1)
                {
                    var data = Report.GetStudentGradesInAllCourses(id);
                    return View(data);
                }
                return RedirectToAction("Login", "Account");

            }
            [HttpGet]
            public IActionResult ExamStudentAnswerView(int id)
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                int? RoleID = HttpContext.Session.GetInt32("RoleId");
                if (UserId != null && RoleID == 1)
                {
                    var data = Report.GetAllExamStudent(id);
                    return View(data);
                }
                return RedirectToAction("Login", "Account");

            }
            [HttpGet]
            public IActionResult ExamStudentAnswer(int id, int studentId)
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                int? RoleID = HttpContext.Session.GetInt32("RoleId");
                if (UserId != null && RoleID == 1)
                {
                    var data = Report.GetExamWithStudentAnswers(id, studentId);
                    return View(data);
                }
                return RedirectToAction("Login", "Account");

            }
      

    }
}
