using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        public List<Reservation> GetReservations();
        public void CreateReservation(Reservation reservation);
        public Reservation GetReservationById(int id);
        public void UpdateReservation(Reservation reservation);
        public void DeleteReservation(Reservation reservation);
        public bool IsReservationAvailable(int reservationId, int workplaceId, DateTime TimeFrom, DateTime TimeTo);

    }
}
