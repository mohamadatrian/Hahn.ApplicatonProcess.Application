using Hahn.ApplicatonProcess.July2021.Domain.Entities;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public byte Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }

        public AssetModel[] Assets { get; set; }
    }
}
