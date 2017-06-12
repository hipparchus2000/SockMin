using System;
using System.Collections.Generic;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.BaseClasses
{
    public partial class DeletableBase : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
