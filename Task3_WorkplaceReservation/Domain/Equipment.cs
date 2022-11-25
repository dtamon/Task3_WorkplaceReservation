namespace Task3_WorkplaceReservation.Domain
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplace> EqForWorkplace { get; set; }
    }
}
