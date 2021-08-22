namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class UserAsset : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}
