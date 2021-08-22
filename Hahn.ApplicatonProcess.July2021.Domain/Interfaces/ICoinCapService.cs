using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Interfaces
{
    public interface ICoinCapService
    {
        Task<CoinCapAssetModel> GetAsset(string assetId);
        Task<CoinCapListAssetModel> GetAllAssets();
    }
}
