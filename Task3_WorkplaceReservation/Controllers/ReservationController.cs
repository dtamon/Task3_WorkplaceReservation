using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EmployeeService;
using Task3_WorkplaceReservation.Services.ReservationService;
using Task3_WorkplaceReservation.Services.WorkplaceService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;

        public ReservationController(IReservationService reservationService, IEmployeeService employeeService, IWorkplaceService workplaceService)
        {
            _reservationService = reservationService;
            _employeeService = employeeService;
            _workplaceService = workplaceService;
        }
        public IActionResult Index()
        {
            return View(_reservationService.GetReservations());
        }

        [HttpGet]
        public IActionResult Create() {
            ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationViewModel model)
        {
            _reservationService.CreateReservation(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            return View(_reservationService.GetReservationById(id));
        }

        [HttpPost]
        public IActionResult Edit(ReservationViewModel model)
        {
            _reservationService.UpdateReservation(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction("Index");
        }
    }
}
