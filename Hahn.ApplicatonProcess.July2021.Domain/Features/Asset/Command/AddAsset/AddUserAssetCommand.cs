using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset
{
    public class AddUserAssetCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string AssetId { get; set; }
        public string AssetSymbol { get; set; }
        public string AssetName { get; set; }
    }
}
