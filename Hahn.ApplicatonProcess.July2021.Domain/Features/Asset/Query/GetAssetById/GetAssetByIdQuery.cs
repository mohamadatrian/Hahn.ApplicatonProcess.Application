using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAssetById
{
    public class GetAssetByIdQuery : IRequest<Entities.Asset>
    {
        public GetAssetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
