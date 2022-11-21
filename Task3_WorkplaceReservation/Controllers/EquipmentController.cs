using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EquipmentService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public IActionResult Index()
        {
            return View(_equipmentService.GetEquipment());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EquipmentViewModel model)
        {
            _equipmentService.CreateEquipment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_equipmentService.GetEquipmentById(id));
        }

        [HttpPost]
        public IActionResult Edit(EquipmentViewModel model)
        {
            _equipmentService.UpdateEquipment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _equipmentService.DeleteEquipment(id);
            return RedirectToAction("Index");
        }

    }
}
