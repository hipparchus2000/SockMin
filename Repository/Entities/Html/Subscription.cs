using System.Collections.Generic;
using Repository.Entities.BaseClasses;
using Repository.Entities.ConnectionAndState;

namespace Repository.Entities.Html
{
    public class Subscription : NamedDeletableBase
    {
        //note the subscription name is used to find the queryHandler
        public List<State> VisibleInStates { get; set; }
    }
}
