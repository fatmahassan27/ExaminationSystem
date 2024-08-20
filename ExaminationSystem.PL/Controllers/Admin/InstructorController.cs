using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.InstructorVM;
using ExaminationSystem.BL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.PL.Controllers.Admin
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepo _instructorRepo;
        public InstructorController(IInstructorRepo instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = _instructorRepo.getAllInstructor();
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult GetInstructorById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                var Data = _instructorRepo.GetInstructorById(id);
                return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult DeleteInstructorByID(int Id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                _instructorRepo.DeleteInstructorByID(Id);
                return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public IActionResult InsertInstructor()
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
        public IActionResult InsertInstructor(InsertInstructorVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (ModelState.IsValid)
                {


                    _instructorRepo.InsertInstructor(model);
                    return RedirectToAction("getAll");
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account");


        }
        public IActionResult Edit(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (id == null)
                    return NotFound();

                var Data = _instructorRepo.GetInstructorDataById(id);
                if (Data == null)
                    return NotFound();
                return View(Data);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Edit(EditInstractorVM model)
        {

            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID == 1)
            {
                if (ModelState.IsValid)
                {
                    _instructorRepo.Edit(model);
                    return RedirectToAction("getAll");
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
