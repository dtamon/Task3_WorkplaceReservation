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
            if(_reservationRepository.IsReservationAvailable(model.Id, model.WorkplaceId, model.TimeFrom, model.TimeTo))
            {
                var reservation = new Reservation()
                {
                    Employee = _employeeRepository.GetEmployeeById(model.EmployeeId),
                    Workplace = _workplaceRepositiory.GetWorkplaceById(model.WorkplaceId),
                    TimeFrom = model.TimeFrom,
                    TimeTo = model.TimeTo
                };
                _reservationRepository.CreateReservation(reservation);
            }
            else
            {
                throw new Exception("Dates collide with another reservation of this Workplace");
            }
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
                Employee = _employeeService.GetEmployeeById(reservation.EmployeeId),
                EmployeeId = reservation.EmployeeId,
                Workplace = _workplaceService.GetWorkplaceById(reservation.WorkplaceId),
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
                    Employee = _employeeService.GetEmployeeById(model.EmployeeId),
                    EmployeeId = model.EmployeeId,
                    Workplace = _workplaceService.GetWorkplaceById(model.WorkplaceId),
                    WorkplaceId = model.WorkplaceId,
                    TimeFrom= model.TimeFrom,
                    TimeTo= model.TimeTo
                });
            }
            return reservations;
        }

        public void UpdateReservation(ReservationViewModel model)
        {
            if (_reservationRepository.IsReservationAvailable(model.Id, model.WorkplaceId, model.TimeFrom, model.TimeTo))
            {
                var reservation = new Reservation()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    WorkplaceId = model.WorkplaceId,
                    TimeFrom = model.TimeFrom,
                    TimeTo = model.TimeTo
                };
                _reservationRepository.UpdateReservation(reservation);
            }
            else
            {
                throw new Exception("Dates collide with another reservation of this Workplace");
            }
        }
    }
}
