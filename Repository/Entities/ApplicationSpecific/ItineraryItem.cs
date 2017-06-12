using System;
using System.Collections.Generic;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.ApplicationSpecific
{
    enum ItineraryItemstatus
    {
        Draft = 0,
        Approved,
        Cancelled
    }
    public class ItineraryItem : DeletableBase
    {
        public string StartingLocation { get; set; }
        public string EndingLocation { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string Notes { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string TripCode { get; set; } // like flight number
        public List<Booking> Bookings { get; set; }

    }
}
