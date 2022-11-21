using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.ReservationRepository
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
            return context.Reservations.Include(e => e.Employee).Include(w =>  w.Workplace).FirstOrDefault(x => x.Id == id);
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
    }
}
