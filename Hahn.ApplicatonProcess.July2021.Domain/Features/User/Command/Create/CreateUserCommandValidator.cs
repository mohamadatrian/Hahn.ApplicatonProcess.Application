using FluentValidation;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Age).NotEmpty().GreaterThan((byte)18);

            RuleFor(p => p.FirstName).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(p => p.LastName).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(p => p.Email).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);

            RuleFor(p => p.Address.HouseNo).NotEmpty();

            RuleFor(p => p.Address.PostalCode).NotEmpty();

            RuleFor(p => p.Address.Street).NotEmpty();
        }
    }
}
