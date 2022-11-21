using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Services.ReservationService
{
    public interface IReservationService
    {
        public void CreateReservation(ReservationViewModel model);
        public void UpdateReservation(ReservationViewModel model);
        public void DeleteReservation(int id);
        public List<ReservationViewModel> GetReservations();
        public ReservationViewModel GetReservationById(int id);
    }
}
