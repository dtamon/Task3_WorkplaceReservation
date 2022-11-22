using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.WorkplaceRepository;

namespace Task3_WorkplaceReservation.Services.WorkplaceService
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;

        public WorkplaceService(IWorkplaceRepository workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public void CreateWorkplace(WorkplaceViewModel model)
        {
            var workplace = new Workplace()
            {
                Floor = model.Floor,
                Room = model.Room,
                Table = model.Table,
            };
            _workplaceRepository.CreateWorkplace(workplace);
        }

        public void DeleteWorkplace(int id)
        {
            var workplace = _workplaceRepository.GetWorkplaceById(id);
            _workplaceRepository.DeleteWorkplace(workplace);
        }

        public WorkplaceViewModel GetWorkplaceById(int id)
        {
            var workplace = _workplaceRepository.GetWorkplaceById(id);
            var model = new WorkplaceViewModel()
            {
                Id = workplace.Id,
                Floor = workplace.Floor,
                Room = workplace.Room,
                Table = workplace.Table,
            };
            return model;
        }

        public List<WorkplaceViewModel> GetWorkplaces()
        {
            var workplaces = new List<WorkplaceViewModel>();
            foreach (var model in _workplaceRepository.GetWorkplaces())
            {
                workplaces.Add(new WorkplaceViewModel()
                {
                    Id = model.Id,
                    Floor = model.Floor,
                    Room = model.Room,
                    Table = model.Table,
                    FullLoc = "Floor=" + model.Floor + "; Room=" + model.Room + "; Table=" + model.Table
                });
            }
            return workplaces;
        }

        public void UpdateWorkplace(WorkplaceViewModel model)
        {
            var workplace = new Workplace()
            {
                Id = model.Id,
                Floor = model.Floor,
                Room = model.Room,
                Table = model.Table,
            };
            _workplaceRepository.UpdateWorkplace(workplace);
        }
    }
}
