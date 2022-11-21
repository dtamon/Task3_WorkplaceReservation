using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ReservationDbContext context;
        public EmployeeRepository(ReservationDbContext context)
        {
            this.context = context;
        }
        public void CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.Include(r => r.Reservations).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return context.Employees.Include(r => r.Reservations).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
        }
    }
}
