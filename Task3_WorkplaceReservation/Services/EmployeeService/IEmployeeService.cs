using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public void CreateEmployee(EmployeeViewModel model);
        public void UpdateEmployee(EmployeeViewModel model);
        public void DeleteEmployee(int id);
        public List<EmployeeViewModel> GetEmployees();
        public EmployeeViewModel GetEmployeeById(int id);
    }
}
