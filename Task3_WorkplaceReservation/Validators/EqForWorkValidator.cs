using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class EqForWorkValidator : AbstractValidator<EqForWorkViewModel>
    {
        public EqForWorkValidator()
        {
            RuleFor(x => x.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.EquipmentId)
                .NotEmpty().WithMessage("Equipment is required");

            RuleFor(x => x.Count)
                .NotNull().WithMessage("Count is required")
                .GreaterThan(0).WithMessage("Count must be greater than 0");
        }
    }
}
