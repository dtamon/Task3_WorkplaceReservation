using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("Employee is required");

            RuleFor(x => x.WorkplaceId)
                .NotEmpty().WithMessage("Workplace is required");

            RuleFor(x => x.TimeFrom)
                .NotEmpty().WithMessage("Reservation From is required");
                //.GreaterThan(DateTime.Now).WithMessage("Start date cannot be past");

            RuleFor(x => x.TimeTo)
                .NotEmpty().WithMessage("Reservation To is required")
                .GreaterThan(x => x.TimeFrom).WithMessage("End date must be later than the start date");
        }
    }
}
