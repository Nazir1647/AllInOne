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

        [HttpPost]
        public IActionResult Create(EmployeePopup form)
        {
            if (ModelState.IsValid)
            {
                _context.employeePopups.Add(form);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_EmployeeModalPartial", form);
        }

    }
}
