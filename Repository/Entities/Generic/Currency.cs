using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Generic
{
    public class Currency : DeletableBase, IEntity
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
    }
}
