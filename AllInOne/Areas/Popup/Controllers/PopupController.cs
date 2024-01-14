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
            var data = _context.employeePopups.ToList();
            return View(data);
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
            if(form.Id == 0)
            {
                _context.employeePopups.Add(form);
                TempData["success"] = "Record saved successfully";
            }
            else
            {
                _context.employeePopups.Update(form);
                TempData["success"] = "Record updated successfully";
            }          
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = _context.employeePopups.FirstOrDefault(x => x.Id == Id);
            if(data == null)
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
            if(data == null)
            {
                return NotFound();
            }
            _context.employeePopups.Remove(data);
            _context.SaveChanges();
            TempData["success"] = "Record deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
