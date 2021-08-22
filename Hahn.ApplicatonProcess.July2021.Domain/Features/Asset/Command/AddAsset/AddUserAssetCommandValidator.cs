using FluentValidation;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset
{
    public class AddUserAssetCommandValidator : AbstractValidator<AddUserAssetCommand>
    {
        public AddUserAssetCommandValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.AssetId).NotEmpty().NotNull();
            RuleFor(p => p.AssetName).NotEmpty().NotNull();
            RuleFor(p => p.AssetSymbol).NotEmpty().NotNull();
        }
    }
}
