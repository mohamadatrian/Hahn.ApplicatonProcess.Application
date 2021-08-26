using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAssetById
{
    public class GetAssetByIdQuery : IRequest<AssetModel>
    {
        public GetAssetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
