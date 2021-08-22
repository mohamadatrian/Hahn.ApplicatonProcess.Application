using MediatR;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Query.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IReadOnlyList<Entities.User>>
    {
    }
}
