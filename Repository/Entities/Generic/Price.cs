using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.ApplicationSpecific;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Generic
{
    public class Price : DeletableBase, IEntity
    {
        public Guid ItineraryItemId { get; set; }
        public ItineraryItem ItineraryItem { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime? ToDateTime { get; set; }
        public bool Active { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }

    }
}
