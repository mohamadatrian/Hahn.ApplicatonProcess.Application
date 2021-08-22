using MediatR;

namespace Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
