namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Asset : EntityBase
    {
        public new string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
