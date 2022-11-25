using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.EquipmentForWorkplaceRepository
{
    public class EquipmentForWorkplaceRepository : IEquipmentForWorkplaceRepository
    {
        private readonly ReservationDbContext context;
        public EquipmentForWorkplaceRepository(ReservationDbContext context)
        {
            this.context = context;
        }

        public void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            context.EqupmentForWorkplace.Add(equipmentForWorkplace);
            context.SaveChanges();
        }

        public void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            context.EqupmentForWorkplace.Remove(equipmentForWorkplace);
            context.SaveChanges();
        }

        public List<EquipmentForWorkplace> GetEquipmentForWorkplace()
        {
            return context.EqupmentForWorkplace.Include(e => e.Equipment).Include(w => w.Workplace).ToList();
        }

        public List<EquipmentForWorkplace> GetEquipmentByWorkplaceId(int id)
        {
            return context.EqupmentForWorkplace.Include(e => e.Equipment).Include(w => w.Workplace).Where(x => x.Workplace.Id == id).ToList();
        }

        public void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            context.EqupmentForWorkplace.Update(equipmentForWorkplace);
            context.SaveChanges();
        }

        public EquipmentForWorkplace GetEquipmentForWorkplaceById(int id)
        {
            return context.EqupmentForWorkplace.Include(e => e.Equipment).Include(w => w.Workplace).FirstOrDefault(x => x.Id == id);
        }

        public bool IsEqAlreadyAssigned(int workplaceId, int equipmentId)
        {
            return context.EqupmentForWorkplace
                .Where(x => x.WorkplaceId == workplaceId && x.EquipmentId == equipmentId).Any();
        }
    }
}
