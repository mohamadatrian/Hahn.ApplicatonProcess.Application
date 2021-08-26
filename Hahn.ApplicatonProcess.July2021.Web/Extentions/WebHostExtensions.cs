using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hahn.ApplicatonProcess.July2021.Web.Extentions
{
    public static class WebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationDbContext>();
                //seed
                var address = new Address
                {
                    HouseNo = "123",
                    PostalCode = "1345767889",
                    Street = "Orumieh"
                };
                context.Users.Add(new User
                {
                    Age = 29,
                    Email = "mohamad.atrian@gmail.com",
                    LastName = "atrian",
                    FirstName = "mohamadreza",
                    Address = address
                });

                context.SaveChanges();
            }

            return host;
        }
    }
}
