using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Query.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<Entities.User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        async Task<IReadOnlyList<Entities.User>> IRequestHandler<GetAllUsersQuery, IReadOnlyList<Entities.User>>.Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Users.GetAsync(includes: new List<Expression<Func<Entities.User, object>>> { x => x.Address });
        }
    }
}
