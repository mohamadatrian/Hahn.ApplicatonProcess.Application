using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class UserModel
    {
        public byte Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<AssetModel> Assets { get; set; }
    }
}
