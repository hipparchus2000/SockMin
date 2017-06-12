using System;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.UserAndPermissions
{
    public class Address : DeletableBase
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public Guid CountryId { get; set; }
    }
}
