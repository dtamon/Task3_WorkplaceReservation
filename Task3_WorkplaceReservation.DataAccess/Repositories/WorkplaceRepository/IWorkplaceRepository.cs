using Task3_WorkplaceReservation.DataAccess.Domain;

namespace Task3_WorkplaceReservation.DataAccess.Repositories.WorkplaceRepository
{
    public interface IWorkplaceRepository
    {
        public List<Workplace> GetWorkplaces();
        public void CreateWorkplace(Workplace workplace);
        public Workplace GetWorkplaceById(int id);
        public void UpdateWorkplace(Workplace workplace);
        public void DeleteWorkplace(Workplace workplace);
    }
}
