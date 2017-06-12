using System;
using System.Collections.Generic;
using Repository.Entities.ApplicationSpecific;
using Repository.Entities.BaseClasses;
using Repository.Entities.Html;

namespace Repository.Entities.UserAndPermissions
{
    public class User : DeletableBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; } //make a hash later
        public bool LockedOut { get; set; }
        public bool Blocked { get; set; }
        public Guid CountryId { get; set; }
        public List<Address> Addresses { get; set; }
        public Guid LanguageId { get; set; }
        public int TimeZoneId { get; set; }
        
        public List<Booking> Bookings { get; set; }
        public List<ContactPoint> ContactPoints { get; set; }
        public List<Role> Roles { get; set; }
        public HtmlStyle HtmlStyle { get; set; }
    }
}
