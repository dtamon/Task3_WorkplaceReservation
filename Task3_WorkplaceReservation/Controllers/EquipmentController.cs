using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EquipmentService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private IValidator<EquipmentViewModel> _validator;
        public EquipmentController(IEquipmentService equipmentService, IValidator<EquipmentViewModel> validator)
        {
            _equipmentService = equipmentService;
            _validator = validator;
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
        public async Task<IActionResult> Create(EquipmentViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create", model);
            }
            _equipmentService.CreateEquipment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_equipmentService.GetEquipmentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create", model);
            }
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
