using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class WorkplaceValidator : AbstractValidator<WorkplaceViewModel>
    {
        public WorkplaceValidator() 
        {
            RuleFor(x => x.Floor)
                .NotEmpty().WithMessage("Floor is required")
                .GreaterThan(0).WithMessage("Floor number must be 1 or greater");

            RuleFor(x => x.Room)
                .NotEmpty().WithMessage("Room is required")
                .GreaterThan(0).WithMessage("Room number must be 1 or greater");


            RuleFor(x => x.Table)
                .NotEmpty().WithMessage("Table is required")
                .GreaterThan(0).WithMessage("Table number must be 1 or greater");
                
        }
    }
}
