namespace Task3_WorkplaceReservation.Domain
{
    public class EquipmentForWorkplace
    {
        public int Id { get; set; }
        public Workplace? Workplace { get; set; }
        public int? WorkplaceId { get; set; }
        public Equipment? Equipment { get; set; }
        public int? EquipmentId { get; set; }
        public int? Count { get; set; } 

    }
}
