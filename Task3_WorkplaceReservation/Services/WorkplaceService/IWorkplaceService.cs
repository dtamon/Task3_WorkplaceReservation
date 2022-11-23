﻿using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Services.WorkplaceService
{
    public interface IWorkplaceService
    {
        public void CreateWorkplace(WorkplaceViewModel model);
        public void UpdateWorkplace(WorkplaceViewModel model);
        public void DeleteWorkplace(int id);
        public List<WorkplaceViewModel> GetWorkplaces();
        public WorkplaceViewModel GetWorkplaceById(int id);
        public EqForWorkpViewModel GetEqForWorkplaceById(int id);
        public void AddEqForWorkplace(EqForWorkpViewModel model);
        public void UpdateEqForWorkplace(EqForWorkpViewModel model);
        public void DeleteEqForWorkplace(int id);
    }
}