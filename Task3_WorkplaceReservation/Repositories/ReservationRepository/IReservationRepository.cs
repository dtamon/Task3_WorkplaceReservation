﻿using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        public List<Reservation> GetReservations();
        public void CreateReservation(Reservation reservation);
        public Reservation GetReservationById(int id);
        public void UpdateReservation(Reservation reservation);
        public void DeleteReservation(Reservation reservation);

    }
}