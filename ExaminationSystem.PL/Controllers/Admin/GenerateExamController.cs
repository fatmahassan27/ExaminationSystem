using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.GenerateExamVM;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers.Admin
{
    public class GenerateExamController:Controller
    {
        private readonly IGenerateExamRepo _generateExamRepo;
        public GenerateExamController(IGenerateExamRepo generateExamRepo)
        {
            _generateExamRepo = generateExamRepo ;
        }
        public IActionResult GenerateExam(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = _generateExamRepo.Get(id);
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult GenerateExam(GenerateExamVM generateExam)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (ModelState.IsValid)
                {
                    _generateExamRepo.Generate(generateExam);
                    return RedirectToAction("getAll", "Student");
                }
                return View(generateExam);
            }
            return RedirectToAction("Login", "Account");

            }
    }
}
