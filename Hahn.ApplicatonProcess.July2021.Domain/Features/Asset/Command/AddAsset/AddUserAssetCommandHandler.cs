using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset
{
    public class AddUserAssetCommandHandler : IRequestHandler<AddUserAssetCommand, string>
    {
        private readonly ICoinCapService _coinCapService;
        private readonly IUnitOfWork _unitOfWork;
        public AddUserAssetCommandHandler(ICoinCapService coinCapService, IUnitOfWork unitOfWork)
        {
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<string> Handle(AddUserAssetCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(Entities.User), request.UserId);

            var asset = await _coinCapService.GetAsset(request.AssetId);
            if (asset == null ||
                !asset.Data.Symbol.Equals(request.AssetSymbol, StringComparison.OrdinalIgnoreCase) ||
                !asset.Data.Name.Equals(request.AssetName, StringComparison.OrdinalIgnoreCase))
                throw new NotFoundException("asset", request.AssetId);

            var assetEntity = await _unitOfWork.Assets.GetByIdAsync(request.AssetId);
            if (assetEntity == null)
                assetEntity = _unitOfWork.Assets.Add(new Entities.Asset
                {
                    Id = asset.Data.Id,
                    Name = asset.Data.Name,
                    Symbol = asset.Data.Symbol
                });

            _unitOfWork.UserAssets.Add(new Entities.UserAsset
            {
                AssetId = assetEntity.Id,
                UserId = user.Id
            });
            await _unitOfWork.CompleteAsync();
            return assetEntity.Id;
        }
    }
}
