using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Create
{
    public class CreateUserCommand : IRequest<int>
    {
        public byte Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
    }
}
