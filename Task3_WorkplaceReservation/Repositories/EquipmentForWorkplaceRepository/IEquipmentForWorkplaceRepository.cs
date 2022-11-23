using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.EquipmentForWorkplaceRepository
{
    public interface IEquipmentForWorkplaceRepository
    {
        public List<EquipmentForWorkplace> GetEquipmentForWorkplace();
        public void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public List<EquipmentForWorkplace> GetEquipmentByWorkplaceId(int id);
        public void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public EquipmentForWorkplace GetEquipmentForWorkplaceById(int id);
    }
}
