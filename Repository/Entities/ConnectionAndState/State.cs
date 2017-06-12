using System.Collections.Generic;
using Repository.Entities.BaseClasses;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.ConnectionAndState
{
    public class State : NamedDeletableBase
    {
        public List<State> LegalNextStates { get; set; }
        public Permission RequiredPermissionForThisState { get; set; }
    }
}
