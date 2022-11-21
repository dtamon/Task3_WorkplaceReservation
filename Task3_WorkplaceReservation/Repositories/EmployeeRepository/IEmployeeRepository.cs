using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public void CreateEmployee(Employee employee);
        public Employee GetEmployeeById(int id);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
    }
}
