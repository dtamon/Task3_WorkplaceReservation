using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.EquipmentForWorkplaceRepository
{
    public interface IEquipmentForWorkplaceRepository
    {
        public List<EquipmentForWorkplace> GetEquipmentForWorkplace();
        public void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public List<EquipmentForWorkplace> GetEquipmentByWorkplaceId(int id);
        public void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace);
        public EquipmentForWorkplace GetEquipmentForWorkplaceById(int id);
        public bool IsEqAlreadyAssigned(int workplaceId, int equipmentId);
    }
}
