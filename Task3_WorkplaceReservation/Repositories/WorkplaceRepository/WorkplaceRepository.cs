using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.Domain;

namespace Task3_WorkplaceReservation.Repositories.WorkplaceRepository
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly ReservationDbContext context;
        public WorkplaceRepository(ReservationDbContext context)
        {
            this.context = context;
        }
        public void CreateWorkplace(Workplace workplace)
        {
            context.Workplaces.Add(workplace);
            context.SaveChanges();
        }

        public void DeleteWorkplace(Workplace workplace)
        {
            context.Workplaces.Remove(workplace);
            context.SaveChanges();
        }

        public Workplace GetWorkplaceById(int id)
        {
            return context.Workplaces.Include(r => r.Reservations).Include(e => e.EqForWorkplace).FirstOrDefault(x => x.Id == id);
        }

        public List<Workplace> GetWorkplaces()
        {
            return context.Workplaces.Include(r => r.Reservations).Include(e => e.EqForWorkplace).ToList();
        }

        public void UpdateWorkplace(Workplace workplace)
        {
            context.Workplaces.Update(workplace);
            context.SaveChanges();
        }
    }
}
