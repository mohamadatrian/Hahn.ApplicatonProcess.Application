using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAllAssets
{
    public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, IEnumerable<AssetModel>>
    {
        private readonly ICoinCapService _coinCapService;
        public GetAllAssetsQueryHandler(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
        }

        public async Task<IEnumerable<AssetModel>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            var endPointAssets = await _coinCapService.GetAllAssets();
            return endPointAssets.Data;
        }
    }
}
