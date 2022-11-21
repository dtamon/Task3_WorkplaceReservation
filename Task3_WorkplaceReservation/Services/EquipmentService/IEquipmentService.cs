using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Services.EquipmentService
{
    public interface IEquipmentService
    {
        public void CreateEquipment(EquipmentViewModel model);
        public void UpdateEquipment(EquipmentViewModel model);
        public void DeleteEquipment(int id);
        public List<EquipmentViewModel> GetEquipment();
        public EquipmentViewModel GetEquipmentById(int id);
    }
}
