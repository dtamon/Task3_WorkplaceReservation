using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.EquipmentRepository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ReservationDbContext context;
        public EquipmentRepository(ReservationDbContext context)
        {
            this.context = context;
        }
        public void CreateEquipment(Equipment equipment)
        {
            context.Equipment.Add(equipment);
            context.SaveChanges();
        }

        public void DeleteEquipment(Equipment equipment)
        {
            context.Equipment.Remove(equipment);
            context.SaveChanges();
        }

        public List<Equipment> GetEquipment()
        {
            return context.Equipment.Include(e => e.EqForWorkplace).ToList();
        }

        public Equipment GetEquipmentById(int id)
        {
            return context.Equipment.Include(e => e.EqForWorkplace).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEquipment(Equipment equipment)
        {
            context.Equipment.Update(equipment);
            context.SaveChanges();
        }
    }
}
