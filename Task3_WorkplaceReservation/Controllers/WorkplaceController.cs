using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EquipmentService;
using Task3_WorkplaceReservation.Services.WorkplaceService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class WorkplaceController : Controller
    {
        private readonly IWorkplaceService _workplaceService;
        private readonly IEquipmentService _equipmentService;

        public WorkplaceController(IWorkplaceService workplaceService, IEquipmentService equipmentService)
        {
            _workplaceService = workplaceService;
            _equipmentService = equipmentService;
        }

        public IActionResult Index()
        {
            return View(_workplaceService.GetWorkplaces());
        }

        [HttpGet] 
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkplaceViewModel model)
        {
            _workplaceService.CreateWorkplace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_workplaceService.GetWorkplaceById(id));
        }

        [HttpPost]
        public IActionResult Edit(WorkplaceViewModel model)
        {
            _workplaceService.UpdateWorkplace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _workplaceService.DeleteWorkplace(id);
            return RedirectToAction("Index");
        }


        //CRUD for EquipmentForWorkplace
        [HttpGet]
        public IActionResult AddEquipment(int id)
        {
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
            return View();
        }

        [HttpPost]
        public IActionResult AddEquipment(EqForWorkpViewModel model)
        {
            _workplaceService.AddEqForWorkplace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEq(int id)
        {
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
            return View(_workplaceService.GetEqForWorkplaceById(id));
        }

        [HttpPost]
        public IActionResult EditEq(EqForWorkpViewModel model)
        {
            _workplaceService.UpdateEqForWorkplace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEq(int id)
        {
            _workplaceService.DeleteEqForWorkplace(id);
            return RedirectToAction("Index");
        }

    }
}
