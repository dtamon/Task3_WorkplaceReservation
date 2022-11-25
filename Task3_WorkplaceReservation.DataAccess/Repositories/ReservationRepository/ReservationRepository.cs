using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext context;
        public ReservationRepository(ReservationDbContext context)
        {
            this.context = context;
        }
        public void CreateReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public Reservation GetReservationById(int id)
        {
            return context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).FirstOrDefault(x => x.Id == id);
        }

        public List<Reservation> GetReservations()
        {
            return context.Reservations.Include(e => e.Employee).Include(w => w.Workplace).ToList();
        }

        public void UpdateReservation(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            context.SaveChanges();
        }

        public bool IsReservationAvailable(int reservationId, int workplaceId, DateTime timeFrom, DateTime timeTo)
        {
            return !context.Reservations
                .Where(x => x.Id != reservationId
                && x.WorkplaceId == workplaceId
                && (timeFrom < x.TimeFrom && x.TimeFrom < timeTo && timeTo < x.TimeTo
                || x.TimeFrom < timeFrom && timeFrom < x.TimeTo && x.TimeTo < timeTo
                || x.TimeFrom < timeFrom && timeFrom < x.TimeTo && x.TimeFrom < timeTo && timeTo < x.TimeTo
                || timeFrom < x.TimeFrom && x.TimeTo < timeTo))
                .Any();
        }
    }
}
