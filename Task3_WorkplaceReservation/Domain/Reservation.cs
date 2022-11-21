namespace Task3_WorkplaceReservation.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Workplace Workplace { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
