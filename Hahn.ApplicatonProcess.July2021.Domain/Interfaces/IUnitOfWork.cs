using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Address> Addresses { get; }
        IRepository<Asset> Assets { get; }
        IRepository<UserAsset> UserAssets { get; }

        Task CompleteAsync();
    }
}
