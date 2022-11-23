using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class EquipmentValidator : AbstractValidator<EquipmentViewModel>
    {
        public EquipmentValidator() 
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Equipment type is required");
        }
    }
}
