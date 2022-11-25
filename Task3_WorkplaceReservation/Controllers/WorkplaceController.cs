using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EquipmentService;
using Task3_WorkplaceReservation.Services.WorkplaceService;
using Task3_WorkplaceReservation.Validators;

namespace Task3_WorkplaceReservation.Controllers
{
    public class WorkplaceController : Controller
    {
        private readonly IWorkplaceService _workplaceService;
        private readonly IEquipmentService _equipmentService;
        private IValidator<WorkplaceViewModel> _workplaceValidator;
        private IValidator<EqForWorkViewModel> _eqForWorkValidator;

        public WorkplaceController(IWorkplaceService workplaceService, IEquipmentService equipmentService, IValidator<WorkplaceViewModel> validator, IValidator<EqForWorkViewModel> eqForWorkValidator)
        {
            _workplaceService = workplaceService;
            _equipmentService = equipmentService;
            _workplaceValidator = validator;
            _eqForWorkValidator = eqForWorkValidator;
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
        public async Task<IActionResult> Create(WorkplaceViewModel model)
        {
            ValidationResult result = await _workplaceValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create", model);
            }
            _workplaceService.CreateWorkplace(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_workplaceService.GetWorkplaceById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkplaceViewModel model)
        {
            ValidationResult result = await _workplaceValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Edit", model);
            }
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
        public async Task<IActionResult> AddEquipment(EqForWorkViewModel model)
        {
            ValidationResult result = await _eqForWorkValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
                return View("AddEquipment", model);
            }
            try
            {
                _workplaceService.AddEqForWorkplace(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
                model.ErrorMessage = e.Message;
                return View("AddEquipment", model);
            }
        }

        [HttpGet]
        public IActionResult EditEq(int id)
        {
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
            return View(_workplaceService.GetEqForWorkplaceById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditEq(EqForWorkViewModel model)
        {
            ValidationResult result = await _eqForWorkValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                ViewBag.EquipmentList = new SelectList(_equipmentService.GetEquipment(), "Id", "Type");
                return View("EditEq", model);
            }
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
