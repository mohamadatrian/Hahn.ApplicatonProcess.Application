using FluentValidation;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset
{
    public class AddUserAssetCommandValidator : AbstractValidator<AddUserAssetCommand>
    {
        public AddUserAssetCommandValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Symbol).NotEmpty().NotNull();
        }
    }
}
