using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Create;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.July2021.Web.SwaggerExamples
{
    public class CreateUserCommandExample : IExamplesProvider<CreateUserCommand>
    {
        public CreateUserCommand GetExamples()
        {
            return new CreateUserCommand
            {
                Address = new Address
                {
                    HouseNo = "123",
                    PostalCode = "67889",
                    Street = "Oroumiyeh"
                },
                Age = 29,
                Email = "mohamad.atrian@gmail.com",
                FirstName = "mohamadreza",
                LastName = "atrian"
            };
        }
    }
}
