using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EmployeeRepository;
using Task3_WorkplaceReservation.Repositories.ReservationRepository;
using Task3_WorkplaceReservation.Repositories.WorkplaceRepository;

namespace Task3_WorkplaceReservation.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWorkplaceRepository _workplaceRepositiory;

        public ReservationService(IReservationRepository reservationRepository, IEmployeeRepository employeeRepository, IWorkplaceRepository workplaceRepositiory)
        {
            _reservationRepository = reservationRepository;
            _employeeRepository = employeeRepository;
            _workplaceRepositiory = workplaceRepositiory;
        }
        public void CreateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                Employee = _employeeRepository.GetEmployeeById(model.EmployeeId),
                Workplace = _workplaceRepositiory.GetWorkplaceById(model.WorkplaceId),
                TimeFrom = model.TimeFrom,
                TimeTo= model.TimeTo
            };
            _reservationRepository.CreateReservation(reservation);
        }

        public void DeleteReservation(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            _reservationRepository.DeleteReservation(reservation);
        }

        public List<Employee> GetEmployeeList()
        {
            return _employeeRepository.GetEmployees();
        }

        public ReservationViewModel GetReservationById(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            var model = new ReservationViewModel()
            {
                Id = reservation.Id,
                Employee = reservation.Employee,
                EmployeeId = reservation.Employee.Id,
                Workplace = reservation.Workplace,
                WorkplaceId = reservation.Workplace.Id,
                TimeFrom = reservation.TimeFrom,
                TimeTo = reservation.TimeTo
            };
            return model;
        }

        public List<ReservationViewModel> GetReservations()
        {
            var reservations = new List<ReservationViewModel>();
            foreach (var model in _reservationRepository.GetReservations())
            {
                reservations.Add(new ReservationViewModel
                {
                    Id= model.Id,
                    Employee = model.Employee,
                    Workplace = model.Workplace,
                    TimeFrom= model.TimeFrom,
                    TimeTo= model.TimeTo
                });
            }
            return reservations;
        }

        public List<Workplace> GetWorkplaceList()
        {
            return _workplaceRepositiory.GetWorkplaces();
        }

        public void UpdateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                Id = model.Id,
                Employee = _employeeRepository.GetEmployeeById(model.EmployeeId),
                Workplace = _workplaceRepositiory.GetWorkplaceById(model.WorkplaceId),
                TimeFrom= model.TimeFrom,
                TimeTo= model.TimeTo
            };
            _reservationRepository.UpdateReservation(reservation);
        }
    }
}
