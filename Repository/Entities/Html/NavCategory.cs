using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities.BaseClasses;
using Repository.Entities.ConnectionAndState;

namespace Repository.Entities.Html
{
    public class NavCategory : NamedDeletableBase
    {
        public List<NavItem> NavItems { get; set; }
        public List<State> VisibleInStates { get; set; }
    }
}
