using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EmployeeService;
using Task3_WorkplaceReservation.Services.ReservationService;
using Task3_WorkplaceReservation.Services.WorkplaceService;
using Task3_WorkplaceReservation.Validators;

namespace Task3_WorkplaceReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;
        private IValidator<ReservationViewModel> _validator;

        public ReservationController(IReservationService reservationService, IEmployeeService employeeService, IWorkplaceService workplaceService, IValidator<ReservationViewModel> validator)
        {
            _reservationService = reservationService;
            _employeeService = employeeService;
            _workplaceService = workplaceService;
            _validator = validator;
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
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {      
                result.AddToModelState(this.ModelState);
                ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                return View("Create", model);
            }
            try
            {
                _reservationService.CreateReservation(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                model.ErrorMessage = e.Message;
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            return View(_reservationService.GetReservationById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                return View("Edit", model);
            }
            try
            {
                _reservationService.UpdateReservation(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result.AddToModelState(this.ModelState);
                ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
                ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
                model.ErrorMessage = e.Message;
                return View("Edit", model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.EmployeeList = new SelectList(_employeeService.GetEmployees(), "Id", "FullName");
            ViewBag.WorkplaceList = new SelectList(_workplaceService.GetWorkplaces(), "Id", "FullLoc");
            return View(_reservationService.GetReservationById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction("Index");
        }
    }
}
