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
#if DEBUG
                //context.Database.EnsureCreated();
                //seed
                var address = new Address
                {
                    HouseNo = "123",
                    PostalCode = "12345",
                    Street = "navvab"
                };
                context.Users.Add(new User
                {
                    Age = 23,
                    Email = "mohamad.atrian@gmail.com",
                    LastName = "atrian",
                    FirstName = "mohamad",
                    Address = address
                });

                context.SaveChanges();
#endif
            }

            return host;
        }
    }
}
