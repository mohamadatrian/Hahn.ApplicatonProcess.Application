using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (userToUpdate == null)
            {
                throw new NotFoundException(nameof(Entities.User), request.Id);
            }

            var entity = _mapper.Map(request, userToUpdate);
            _unitOfWork.Addresses.Update(entity.Address);
            _unitOfWork.Users.Update(entity);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
