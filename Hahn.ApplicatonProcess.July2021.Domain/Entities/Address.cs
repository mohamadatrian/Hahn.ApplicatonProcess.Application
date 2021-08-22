namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Address : EntityBase
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
    }
}
