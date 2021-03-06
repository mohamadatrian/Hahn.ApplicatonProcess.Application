using Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.July2021.Web.SwaggerExamples
{
    public class AddUserAssetCommandExample : IExamplesProvider<AddUserAssetCommand>
    {
        public AddUserAssetCommand GetExamples()
        {
            return new AddUserAssetCommand
            {
                Id = "bitcoin",
                Name = "Bitcoin",
                Symbol = "BTC",
                UserId = 1
            };
        }
    }
}
