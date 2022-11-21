using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
