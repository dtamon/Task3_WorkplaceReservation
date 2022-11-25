using Task3_WorkplaceReservation.DataAccess.Domain;
using Task3_WorkplaceReservation.DataAccess.Repositories.EmployeeRepository;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void CreateEmployee(EmployeeViewModel model)
        {
            var emp = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _employeeRepository.CreateEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            _employeeRepository.DeleteEmployee(emp);
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            var model = new EmployeeViewModel()
            {
                Id = emp.Id, 
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                FullName = emp.FirstName + " " + emp.LastName
            };
            return model;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees().ConvertAll(x => new EmployeeViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FirstName+ " " + x.LastName
            });
            return employees;
        }

        public void UpdateEmployee(EmployeeViewModel model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            _employeeRepository.UpdateEmployee(emp);
        }
    }
}
