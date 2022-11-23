using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class WorkplaceValidator : AbstractValidator<WorkplaceViewModel>
    {
        public WorkplaceValidator() 
        {
            RuleFor(x => x.Floor)
                .NotNull().WithMessage("Floor is required")
                .GreaterThan(-1).WithMessage("Floor number cannot be negative");

            RuleFor(x => x.Room)
                .NotNull().WithMessage("Room is required")
                .GreaterThan(0).WithMessage("Room number must be 1 or greater");


            RuleFor(x => x.Table)
                .NotNull().WithMessage("Table is required")
                .GreaterThan(0).WithMessage("Table number must be 1 or greater");
                
        }
    }
}
