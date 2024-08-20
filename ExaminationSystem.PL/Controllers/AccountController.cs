using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepo _loginRepo;
        public AccountController(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var user = _loginRepo.IsValid(loginVM);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetInt32("RoleId", (int)user.RoleId);
                    if (user.RoleId == 2)
                    {
                        //Go to Pre Exam Page
                        return RedirectToAction("StudentProfile", "PreExam");
                    }
                    else
                    {
                        return RedirectToAction("GetAll", "Student");
                    }
                }
            }
            return View(loginVM);
        }
    }
}
