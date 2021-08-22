using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAllAssets
{
    public class GetAllAssetsQuery : IRequest<IEnumerable<AssetModel>>
    {
    }
}
