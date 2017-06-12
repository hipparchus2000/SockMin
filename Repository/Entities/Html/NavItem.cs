using Repository.Entities.BaseClasses;
using Repository.Entities.ConnectionAndState;

namespace Repository.Entities.Html
{
    public class NavItem : NamedDeletableBase
    {
        public State ChangeToStateOnClick { get; set; }
    }
}
