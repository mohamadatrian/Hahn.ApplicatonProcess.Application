using Hahn.ApplicatonProcess.July2021.Domain.Models;
using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Query.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
