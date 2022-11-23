using FluentValidation;
using Task3_WorkplaceReservation.Models;

namespace Task3_WorkplaceReservation.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .Length(2, 20).WithMessage("First Name must be between 2 - 20 characters")
                .Matches("^[A-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$").WithMessage("First Name cannot contain numbers and must start with capital letter");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .Length(2, 20).WithMessage("Last Name must be between 2 - 20 characters")
                .Matches("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$").WithMessage("Last Name cannot contain numbers");

        }
    }
}
