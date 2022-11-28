using Task3_WorkplaceReservation.DataAccess.Domain;
using Task3_WorkplaceReservation.DataAccess.Repositories.EquipmentRepository;
using Task3_WorkplaceReservation.Models;

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
            if (!_equipmentRepository.IsEquipmentInDb(model.Id, model.Type))
            {
                var eq = new Equipment()
                {
                    Type = model.Type
                };
                _equipmentRepository.CreateEquipment(eq);
            }
            else
            {
                throw new Exception("Equipment with that type already exists in database");
            }
                
        }

        public void DeleteEquipment(int id)
        {
            var eq = _equipmentRepository.GetEquipmentById(id);
            _equipmentRepository.DeleteEquipment(eq);
        }

        public List<EquipmentViewModel> GetEquipment()
        {
            var equipment = _equipmentRepository.GetEquipment().ConvertAll(x => new EquipmentViewModel()
            {
                Id = x.Id,
                Type = x.Type,
            });
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
            if (!_equipmentRepository.IsEquipmentInDb(model.Id, model.Type))
            {
                var eq = new Equipment()
                {
                    Id = model.Id,
                    Type = model.Type
                };
                _equipmentRepository.UpdateEquipment(eq);
            }
            else
            {
                throw new Exception("Equipment with that type already exists in database");
            }            
        }
    }
}
