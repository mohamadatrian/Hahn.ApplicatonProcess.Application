using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicatonProcess.July2021.Data.EntityConfigurations
{
    class UserAssetEntityTypeConfiguration
        : IEntityTypeConfiguration<UserAsset>
    {
        public void Configure(EntityTypeBuilder<UserAsset> builder)
        {
            builder.HasKey(x => new { x.AssetId, x.UserId });
            builder.HasAlternateKey(x => x.Id);

            builder
           .HasOne(s => s.Asset)
           .WithMany()
           .HasForeignKey(ad => ad.AssetId);

            builder
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(ad => ad.UserId);
        }
    }
}
