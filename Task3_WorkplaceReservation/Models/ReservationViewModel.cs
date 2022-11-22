using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Workplace Workplace { get; set; }
        public int WorkplaceId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
