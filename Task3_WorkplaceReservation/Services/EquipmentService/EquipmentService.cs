using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EquipmentRepository;

namespace Task3_WorkplaceReservation.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public void CreateEquipment(EquipmentViewModel model)
        {
            var eq = new Equipment()
            {
                Type = model.Type
            };
            _equipmentRepository.CreateEquipment(eq);
        }

        public void DeleteEquipment(int id)
        {
            var eq = _equipmentRepository.GetEquipmentById(id);
            _equipmentRepository.DeleteEquipment(eq);
        }

        public List<EquipmentViewModel> GetEquipment()
        {
            var equipment = new List<EquipmentViewModel>();
            foreach(var model in _equipmentRepository.GetEquipment())
            {
                equipment.Add(new EquipmentViewModel
                {
                    Id = model.Id,
                    Type = model.Type
                });
            }
            return equipment;
        }

        public EquipmentViewModel GetEquipmentById(int id)
        {
            var eq = _equipmentRepository.GetEquipmentById(id);
            var model = new EquipmentViewModel()
            {
                Id = eq.Id,
                Type = eq.Type
            };
            return model;
        }

        public void UpdateEquipment(EquipmentViewModel model)
        {
            var eq = new Equipment()
            {
                Id = model.Id,
                Type = model.Type
            };
            _equipmentRepository.UpdateEquipment(eq);
        }
    }
}
