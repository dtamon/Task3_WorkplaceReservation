using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EmployeeRepository;
using Task3_WorkplaceReservation.Repositories.ReservationRepository;

namespace Task3_WorkplaceReservation.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ReservationService(IReservationRepository reservationRepository, IEmployeeRepository employeeRepository)
        {
            _reservationRepository = reservationRepository;
            _employeeRepository = employeeRepository;
        }
        public void CreateReservation(ReservationViewModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public ReservationViewModel GetReservationById(int id)
        {
            throw new NotImplementedException();
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

        public void UpdateReservation(ReservationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
