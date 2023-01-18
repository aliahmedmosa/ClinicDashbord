using AliMosaclinicTask.Data;
using AliMosaclinicTask.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace AliMosaclinicTask.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _ToastNotification;
        public DoctorController(ApplicationDbContext context, IToastNotification ToastNotification)
        {
            _context = context;
            _ToastNotification = ToastNotification;
        }

        public IActionResult Index()
        {
            return View(_context.Doctors.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Doctor model)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(model);
                _context.SaveChanges();
                _ToastNotification.AddSuccessToastMessage("Appointment added successfully !");
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            
            var result = _context.Doctors.FirstOrDefault(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor model)
        {

            if (ModelState.IsValid)
            {
                _context.Doctors.Update(model);
                _context.SaveChanges();
                _ToastNotification.AddAlertToastMessage("Appointment edited successfully !");
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        //ajax delete Action
        public IActionResult Delete(int id)
        {
            Doctor? doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
