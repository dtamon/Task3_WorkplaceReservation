namespace Task3_WorkplaceReservation.DataAccess.Domain
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EquipmentForWorkplace> EqForWorkplace { get; set; }
    }
}
