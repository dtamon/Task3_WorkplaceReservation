using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.Models
{
    public class WorkplaceViewModel
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public string FullLoc { get; set; }

        public List<EquipmentForWorkplace> EqForWorkplace { get; set; }
    }
}
