using System;
using Repository.Entities.BaseClasses;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.ConnectionAndState
{
    public class Connection: IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }  //0000-0000-00000 when not logged in
        public User User { get; set; }
        public Guid CurrentStateId { get; set; }
        public State CurrentState { get; set; }
        public Guid SocketIdentifier { get; set; }

    }
}
