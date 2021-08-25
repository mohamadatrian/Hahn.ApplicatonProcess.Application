using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset
{
    public class AddUserAssetCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
