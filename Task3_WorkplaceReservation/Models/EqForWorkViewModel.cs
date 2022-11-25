using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Models
{
    public class EqForWorkViewModel
    {
        public int Id { get; set; }
        public WorkplaceViewModel Workplace { get; set; }
        public int WorkplaceId { get; set; }
        public EquipmentViewModel Equipment { get; set; }
        public int EquipmentId { get; set; }
        public int Count { get; set; }
        public string ErrorMessage { get; set; }
    }
}
