using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Services.EmployeeService;

namespace Task3_WorkplaceReservation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.GetEmployees());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            _employeeService.CreateEmployee(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            _employeeService.UpdateEmployee(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}