using Hahn.ApplicatonProcess.July2021.Domain.Extensions;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Services
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _client;

        public CoinCapService(HttpClient client)
        {
            _client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        public async Task<CoinCapAssetModel> GetAsset(string assetId)
        {
            var response = await _client.GetAsync($"assets/{assetId}");
            return await response.ReadContentAs<CoinCapAssetModel>();
        }

        public async Task<CoinCapListAssetModel> GetAllAssets()
        {
            var response = await _client.GetAsync($"assets");
            return await response.ReadContentAs<CoinCapListAssetModel>();
        }
    }
}
