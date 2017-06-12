using System;
using System.Collections.Generic;
using Repository.Entities.BaseClasses;
using Repository.Entities.UserAndPermissions;

namespace Repository.Entities.ApplicationSpecific
{
    public class Vehicle : DeletableBase
    {
        public string Name { get; set; }
        public string HtmlDescription { get; set; }
        public string RegistrationMark { get; set; } //like Licence plate number
        public User Manager { get; set; }
        public Guid ManagerId { get; set; }
        public int Capacity { get; set; }  //in persons
        public List<ItineraryItem> ItineraryItems { get; set; }
    }
}
