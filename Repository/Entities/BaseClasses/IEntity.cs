using System;

namespace Repository.Entities.BaseClasses
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
