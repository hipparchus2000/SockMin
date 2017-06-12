using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.Generic
{
    public class Country : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryCode2 { get; set; }
        public string CountryCode3 { get; set; }
    }
}
