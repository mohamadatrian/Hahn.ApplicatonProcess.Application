using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IRepository<User> Users { get; }
        public IRepository<Address> Addresses { get; }
        public IRepository<Asset> Assets { get; }
        public IRepository<UserAsset> UserAssets { get; }

        public UnitOfWork(ApplicationDbContext context,
            IRepository<User> userRepository,
            IRepository<Asset> assetRepository,
            IRepository<UserAsset> userAssetRepository,
            IRepository<Address> addresses)
        {
            _context = context;
            Users = userRepository;
            Assets = assetRepository;
            UserAssets = userAssetRepository;
            Addresses = addresses;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
