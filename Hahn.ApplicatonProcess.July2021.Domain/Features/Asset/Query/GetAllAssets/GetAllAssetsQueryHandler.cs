using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAllAssets
{
    public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, IEnumerable<AssetModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoinCapService _coinCapService;
        private readonly IMapper _mapper;
        public GetAllAssetsQueryHandler(IUnitOfWork unitOfWork, ICoinCapService coinCapService, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AssetModel>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            var assets = await _unitOfWork.Assets.GetAllAsync();
            var assetsModel = _mapper.Map<IEnumerable<AssetModel>>(assets);

            var endPointAssets = await _coinCapService.GetAllAssets();

            assetsModel = endPointAssets.Data.Intersect(assetsModel, new AssetModelComparer());
            return assetsModel;
        }
    }
}
