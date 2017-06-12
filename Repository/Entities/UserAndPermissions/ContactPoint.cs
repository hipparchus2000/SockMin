using Repository.Entities.BaseClasses;

namespace Repository.Entities.UserAndPermissions
{
    public enum ContactPointType
    {
        HomePhone = 0,
        WorkPhone,
        Mobile,
        Email,
        Skype
    }

    public class ContactPoint : DeletableBase
    {
        public User User { get; set; }
        public ContactPointType ContactPointType { get; set; }
        public string Value { get; set; }
    }
}
