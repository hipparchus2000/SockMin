using System.Collections.Generic;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.BaseClasses
{
    public partial class NamedDeletableBase: DeletableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Permission> RequiredPermissionsForView { get; set; }
    }
}
