using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAssetById
{
    public class GetAssetByIdQueryHandler : IRequestHandler<GetAssetByIdQuery, AssetModel>
    {
        private readonly ICoinCapService _coinCapService;
        public GetAssetByIdQueryHandler(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
        }

        public async Task<AssetModel> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            var asset = await _coinCapService.GetAsset(request.Id);
            if (asset == null)
                throw new NotFoundException(nameof(Entities.Asset), request.Id);
            return asset.Data;
        }
    }
}
