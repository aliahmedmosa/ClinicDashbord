using AliMosaclinicTask.Data;
using AliMosaclinicTask.Models;
using AliMosaclinicTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace AliMosaclinicTask.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _ToastNotification;
        public AppointmentController(ApplicationDbContext context, IToastNotification ToastNotification)
        {
            _context = context;
            _ToastNotification = ToastNotification;
        }
        public IActionResult Index()
        {
            var data = _context.Appointments.Include(x => x.Doctor).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.DoctorsList = _context.Doctors.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Appointment model)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(model);
                _context.SaveChanges();
                _ToastNotification.AddSuccessToastMessage("Appointment added successfully !");
                return RedirectToAction("Index");
            }
            ViewBag.DoctorsList = _context.Doctors.ToList();
            return View();
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.DoctorsList = _context.Doctors.ToList();
            var result = _context.Appointments.FirstOrDefault(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment model)
        {
            
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(model);
                _context.SaveChanges();
                _ToastNotification.AddAlertToastMessage("Appointment edited successfully !");
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsList = _context.Doctors.ToList();
            return View(model);
        }

        //ajax delete Action
        public IActionResult Delete(int id)
        {
            Appointment? appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }

            return Ok();
        }

        public IActionResult AppointmentPerDoctor(int id)
        {
            var today = DateTime.Today;
            var data = _context.Appointments.Include(x => x.Doctor).Where(x=>x.DoctorID==id&&x.AppointmentDate.Date==today).ToList();
            ViewBag.DoctorID = id;
            return View(data);
        }

        public IActionResult Search(AppointmentSearchVM model)
        {
            ViewBag.DoctorID = model.ID;
            
            var data = _context.Appointments.Include(x => x.Doctor).
               Where(x => x.AppointmentDate.Date >= model.AppointmentStartDate && x.AppointmentDate.Date <= model.AppointmentEndDate && x.DoctorID == model.ID).ToList();
            return View(data);
        }

        

    }
}