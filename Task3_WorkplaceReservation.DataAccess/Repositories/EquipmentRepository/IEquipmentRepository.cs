using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.EquipmentRepository
{
    public interface IEquipmentRepository
    {
        public List<Equipment> GetEquipment();
        public void CreateEquipment(Equipment equipment);
        public Equipment GetEquipmentById(int id);
        public void UpdateEquipment(Equipment equipment);
        public void DeleteEquipment(Equipment equipment);
        public bool IsEquipmentInDb(int id, string type);
    }
}
