using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.ReservationService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            return View(_reservationService.GetReservations());
        }

        [HttpGet]
        public IActionResult Create() {
            ViewBag.EmployeeList = new SelectList(_reservationService.GetEmployeeList(), "Id", "FirstName", "LastName");
            ViewBag.WorkplaceList = new SelectList(_reservationService.GetWorkplaceList(), "Id", "Floor", "Room", "Table");
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
            ViewBag.EmployeeList = new SelectList(_reservationService.GetEmployeeList(), "Id", "FirstName", "LastName");
            ViewBag.WorkplaceList = new SelectList(_reservationService.GetWorkplaceList(), "Id", "Floor", "Room", "Table");
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
