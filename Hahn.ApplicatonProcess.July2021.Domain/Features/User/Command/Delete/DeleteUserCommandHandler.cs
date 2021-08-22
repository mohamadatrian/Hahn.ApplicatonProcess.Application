using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(Entities.User), request.Id);
            }

            _unitOfWork.Users.Delete(userToDelete);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
