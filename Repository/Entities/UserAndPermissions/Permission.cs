using System;
using Repository.Entities.BaseClasses;

namespace Repository.Entities.UserAndPermissions
{
    public class Permission : DeletableBase
    {
        public PermissionCategory PermissionCategory { get; set; }
        public Guid PermissionCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
