using System;
using Repository.Entities.BaseClasses;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.ApplicationSpecific
{
    public class Booking : DeletableBase
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ItineraryItem ItineraryItem { get; set; }
        public Guid ItineraryItemId { get; set; }
        public string Notes { get; set; } //eg dietary requirements
    }

}
