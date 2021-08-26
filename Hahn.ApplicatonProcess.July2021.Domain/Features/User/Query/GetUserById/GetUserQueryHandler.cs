using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Query.GetUserById
{
    public class GetUserQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoinCapService _coinCapService;
        public GetUserQueryHandler(IMapper mapper, ICoinCapService coinCapService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _coinCapService = coinCapService ?? throw new ArgumentNullException(nameof(coinCapService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(Entities.User), request.Id);
            var address = await _unitOfWork.Addresses.GetByIdAsync(user.Id);
            if (address == null)
                throw new NotFoundException(nameof(Entities.Address), user.Id);
            user.Address = address;

            var assets = await _unitOfWork.UserAssets.GetAsync(x => x.UserId == user.Id);

            var userModel = _mapper.Map<UserModel>(user);

            var taskList = new List<Task<CoinCapAssetModel>>();
            foreach (var asset in assets)
            {
                var task = _coinCapService.GetAsset(asset.AssetId);
                taskList.Add(task);
            }
            await Task.WhenAll(taskList);

            userModel.Assets = taskList.Select(x => x.Result.Data).ToArray();
            return userModel;
        }
    }
}
