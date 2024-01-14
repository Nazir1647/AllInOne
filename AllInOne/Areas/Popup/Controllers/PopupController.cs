using AllInOne.Data;
using AllInOne.Entity.Models.Popup;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.Popup.Controllers
{
    [Area("Popup")]
    public class PopupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PopupController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var data = _context.employeePopups.ToList();
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Save = "Save";
            EmployeePopup emp = new EmployeePopup();
            return PartialView("_EmployeeModalPartial", emp);
        }

        [HttpPost]
        public IActionResult Create(EmployeePopup form)
        {
            if (form.Id == 0)
            {
                _context.employeePopups.Add(form);
            }
            else
            {
                _context.employeePopups.Update(form);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = _context.employeePopups.FirstOrDefault(x => x.Id == Id);
            if (data == null)
            {
                return Json(false);
            }
            ViewBag.Save = "Update";
            return PartialView("_EmployeeModalPartial", data);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = _context.employeePopups.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _context.employeePopups.Remove(data);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult AlertMessage(string type, string msg)
        {
            TempData["type"] = type;
            TempData["msg"] = msg;
            return PartialView("_NotificationPartial");
        }
    }
}
