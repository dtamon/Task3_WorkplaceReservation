using Microsoft.AspNetCore.Mvc.Rendering;
using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EmployeeRepository;
using Task3_WorkplaceReservation.Repositories.ReservationRepository;
using Task3_WorkplaceReservation.Repositories.WorkplaceRepository;
using Task3_WorkplaceReservation.Services.EmployeeService;
using Task3_WorkplaceReservation.Services.WorkplaceService;

namespace Task3_WorkplaceReservation.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWorkplaceRepository _workplaceRepositiory;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;

        public ReservationService(IReservationRepository reservationRepository, IEmployeeRepository employeeRepository, IWorkplaceRepository workplaceRepositiory, IWorkplaceService workplaceService, IEmployeeService employeeService)
        {
            _reservationRepository = reservationRepository;
            _employeeRepository = employeeRepository;
            _workplaceRepositiory = workplaceRepositiory;
            _workplaceService = workplaceService;
            _employeeService = employeeService;
        }
        public void CreateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                Employee = _employeeRepository.GetEmployeeById((int)model.EmployeeId),
                Workplace = _workplaceRepositiory.GetWorkplaceById((int)model.WorkplaceId),
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

        public ReservationViewModel GetReservationById(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            var model = new ReservationViewModel()
            {
                Id = reservation.Id,
                Employee = _employeeService.GetEmployeeById((int)reservation.EmployeeId),
                EmployeeId = reservation.EmployeeId,
                Workplace = _workplaceService.GetWorkplaceById((int)reservation.WorkplaceId),
                WorkplaceId = reservation.WorkplaceId,
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
                    Employee = _employeeService.GetEmployeeById((int)model.EmployeeId),
                    EmployeeId = model.EmployeeId,
                    Workplace = _workplaceService.GetWorkplaceById((int)model.WorkplaceId),
                    WorkplaceId = model.WorkplaceId,
                    TimeFrom= model.TimeFrom,
                    TimeTo= model.TimeTo
                });
            }
            return reservations;
        }

        public void UpdateReservation(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                WorkplaceId = model.WorkplaceId,
                TimeFrom= model.TimeFrom,
                TimeTo= model.TimeTo
            };
            _reservationRepository.UpdateReservation(reservation);
        }
    }
}
