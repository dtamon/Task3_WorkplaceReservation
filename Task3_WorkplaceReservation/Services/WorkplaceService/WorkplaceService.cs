﻿using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EquipmentForWorkplaceRepository;
using Task3_WorkplaceReservation.Repositories.WorkplaceRepository;
using Task3_WorkplaceReservation.Services.EquipmentService;

namespace Task3_WorkplaceReservation.Services.WorkplaceService
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;
        private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;
        private readonly IEquipmentService _equipmentService;

        public WorkplaceService(IWorkplaceRepository workplaceRepository, IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository, IEquipmentService equipmentService)
        {
            _workplaceRepository = workplaceRepository;
            _equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
            _equipmentService = equipmentService;
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
                FullLoc = "Floor=" + workplace.Floor + "; Room=" + workplace.Room + "; Table=" + workplace.Table,
                EqForWorkplace = _equipmentForWorkplaceRepository.GetEquipmentByWorkplaceId(id)
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
                    FullLoc = "Floor=" + model.Floor + "; Room=" + model.Room + "; Table=" + model.Table,
                    EqForWorkplace = _equipmentForWorkplaceRepository.GetEquipmentByWorkplaceId(model.Id),
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

        //EquipmentForWorkplace crud methods
        public void AddEqForWorkplace(EqForWorkViewModel model)
        {
            var eqForWorkp = new EquipmentForWorkplace()
            {
                WorkplaceId = model.WorkplaceId,
                EquipmentId = model.EquipmentId,
                Count = model.Count
            };
            _equipmentForWorkplaceRepository.CreateEquipmentForWorkplace(eqForWorkp);
        }
        public void UpdateEqForWorkplace(EqForWorkViewModel model)
        {
            var eqForWorkp = new EquipmentForWorkplace()
            {
                Id = model.Id,
                WorkplaceId = model.WorkplaceId,
                EquipmentId = model.EquipmentId,
                Count = model.Count
            };
            _equipmentForWorkplaceRepository.UpdateEquipmentForWorkplace(eqForWorkp);
        }
        public EqForWorkViewModel GetEqForWorkplaceById(int id)
        {
            var eqForWorkp = _equipmentForWorkplaceRepository.GetEquipmentForWorkplaceById(id);
            var model = new EqForWorkViewModel()
            {
                Id = eqForWorkp.Id,
                Workplace = GetWorkplaceById(eqForWorkp.WorkplaceId),
                WorkplaceId = eqForWorkp.WorkplaceId,
                Equipment = _equipmentService.GetEquipmentById(eqForWorkp.EquipmentId),
                EquipmentId = eqForWorkp.EquipmentId,
                Count = eqForWorkp.Count
            };
            return model;
        }
        public void DeleteEqForWorkplace(int id)
        {
            var eq = _equipmentForWorkplaceRepository.GetEquipmentForWorkplaceById(id);
            _equipmentForWorkplaceRepository.DeleteEquipmentForWorkplace(eq);
        }
    }
}
