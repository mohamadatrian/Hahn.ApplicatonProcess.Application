using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class AssetModel
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
    }

    public class AssetModelComparer : IEqualityComparer<AssetModel>
    {
        public bool Equals(AssetModel x, AssetModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(AssetModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
