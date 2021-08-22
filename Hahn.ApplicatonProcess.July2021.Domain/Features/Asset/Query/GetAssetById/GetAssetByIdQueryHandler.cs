using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAssetById
{
    public class GetAssetByIdQueryHandler : IRequestHandler<GetAssetByIdQuery, Entities.Asset>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoinCapService _coinCapService;
        private readonly IMapper _mapper;
        public GetAssetByIdQueryHandler(IUnitOfWork unitOfWork, ICoinCapService coinCapService, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Entities.Asset> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            var asset = await _unitOfWork.Assets.GetByIdAsync(request.Id);
            if (asset == null)
                throw new NotFoundException(nameof(Entities.Asset), request.Id);

            return asset;
        }
    }
}
