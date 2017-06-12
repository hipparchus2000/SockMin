using System.Collections.Generic;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.UserAndPermissions
{
    public class Role : DeletableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
