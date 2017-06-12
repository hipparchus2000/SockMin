using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Entities.ConnectionAndState;
using Repository.Entities.Html;
using Repository.Entities.UserAndPermissions;

namespace Repository
{
    public class SockMinInitializer 
    {
        public void Seed(SockMinDbContext context)
        {
            context.Connections.RemoveRange(context.Connections);
            context.Users.RemoveRange(context.Users);
            context.Roles.RemoveRange(context.Roles);
            context.PermissionCategories.RemoveRange(context.PermissionCategories);
            context.Permissions.RemoveRange(context.Permissions);
            context.States.RemoveRange(context.States);
            context.SaveChanges();

            //var maps = new List<Map>
            //{
            //    new Map{EntityName = "",PropertyName = "", HtmlPrefix = "", HtmlSuffix = "",Type = "",ViewName = ""},
            //};
            //maps.ForEach(s => context.Maps.Add(s));
            //context.SaveChanges();

            var entities = new List<string>
            {
                "Booking",
                "Vehicle",
                "ItineraryItem",

                "User",
                "Role",
                "PermissionCategory",
                "Permission",
                "State",
                "ContactPoint",
                "Address",

                "ContentItem",
                "HtmlStyle",
                "Map",
                "NavCategory",
                "NavItem",
                "StatusBarItem",
                "Subscription",

                "Cost",
                "Price",
                "LogEntry",
                "Currency",
                "Country"
            };
            foreach (var entity in entities)
            {
                //context.PermissionCategories.Add(new PermissionCategory { Id=Guid.NewGuid(), Name = $"{entity}", Description = $"{entity}", Created = DateTime.UtcNow });
                //context.SaveChanges();

                //var permissions = new List<Permission>
                //    {
                //        new Permission{ Id=Guid.NewGuid(), Name = $"View{entity}", Description = $"View {entity}", Created = DateTime.UtcNow },
                //        new Permission{ Id=Guid.NewGuid(), Name = $"Create{entity}", Description = $"Create {entity}", Created = DateTime.UtcNow },
                //        new Permission{ Id=Guid.NewGuid(), Name = $"Update{entity}", Description = $"Update {entity}", Created = DateTime.UtcNow },
                //        new Permission{ Id=Guid.NewGuid(), Name = $"Delete{entity}", Description = $"Delete {entity}", Created = DateTime.UtcNow },
                //    };
                //permissions.ForEach(s => context.Permissions.Add(s));
                //context.SaveChanges();
            }
            //update permission categories to contain the permissions


            var roles = new List<Role>
            {
                new Role { Id=Guid.NewGuid(), Name ="user", Description = "regular user", Created = DateTime.UtcNow},
                new Role { Id=Guid.NewGuid(), Name ="admin", Description = "administrator", Created = DateTime.UtcNow},
                new Role { Id=Guid.NewGuid(), Name ="vehicleManager", Description = "vehicle manager", Created = DateTime.UtcNow},
                new Role { Id=Guid.NewGuid(), Name ="programmer", Description = "programmer", Created = DateTime.UtcNow, Permissions = context.Permissions.ToList()},
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
            

            var users = new List<User>
            {
                new User {Id=Guid.NewGuid(), FirstName = "John", LastName = "Smith", Created = DateTime.UtcNow, Password = "thx1138", Roles = context.Roles.Where(r=>r.Name == "programmer").ToList()},
                new User {Id=new Guid(), FirstName = "Not", LastName = "LoggedIn", Created = DateTime.UtcNow, Password = "", Roles = context.Roles.Where(r=>r.Name == "programmer").ToList()}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var states = new List<State>
            {
                new State { Id=Guid.NewGuid(),  Name = "NotLoggedIn", Created = DateTime.UtcNow, Description = "Not Logged In" },
                new State { Id=Guid.NewGuid(), Name = "LogIn", Created = DateTime.UtcNow, Description = "Please Log In" },
                new State { Id=Guid.NewGuid(), Name = "LoggedIn", Created = DateTime.UtcNow, Description = "Logged In" },
            };


            foreach (var entity in entities)
            {
                states.AddRange(MakeStatesForEntity(entity));
            }
                //application specific
                
            states.AddRange(MakeStatesForEntity("Vehicle"));
            states.AddRange(MakeStatesForEntity("ItineraryItem"));

            //user
            states.AddRange(MakeStatesForEntity("User"));
            states.AddRange(MakeStatesForEntity("Role"));
            states.AddRange(MakeStatesForEntity("PermissionCategory"));
            states.AddRange(MakeStatesForEntity("Permission"));
            states.AddRange(MakeStatesForEntity("State"));
            states.AddRange(MakeStatesForEntity("ContactPoint"));

            //html
            states.AddRange(MakeStatesForEntity("ContentItem"));
            states.AddRange(MakeStatesForEntity("HtmlStyle"));
            states.AddRange(MakeStatesForEntity("Map"));
            states.AddRange(MakeStatesForEntity("NavCategory"));
            states.AddRange(MakeStatesForEntity("NavItem"));
            states.AddRange(MakeStatesForEntity("StatusBarItem"));
            states.AddRange(MakeStatesForEntity("Subscription"));

            //generic
            states.AddRange(MakeStatesForEntity("Cost"));
            states.AddRange(MakeStatesForEntity("Price"));
            states.AddRange(MakeStatesForEntity("LogEntry"));
            states.AddRange(MakeStatesForEntity("Currency"));
            states.AddRange(MakeStatesForEntity("Country"));
            states.ForEach(s => context.States.Add(s));
            context.SaveChanges();

            
            // public List<State> LegalNextStates { get; set; }
            //public Permission RequiredPermissionForThisState { get; set; }
            //public List<Permission> RequiredPermissionsForView { get; set; }


        }

        private IEnumerable<State> MakeStatesForEntity(string entityName)
        {
            return new List<State>
            {
                new State { Id=Guid.NewGuid(),  Name = $"View{entityName}s", Created = DateTime.UtcNow, Description = $"View {entityName}s" },
                new State { Id=Guid.NewGuid(),  Name = $"View{entityName}", Created = DateTime.UtcNow, Description = $"View {entityName}" },
                new State { Id=Guid.NewGuid(),  Name = $"Create{entityName}", Created = DateTime.UtcNow, Description = $"Create {entityName}" },
                new State { Id=Guid.NewGuid(),  Name = $"Created{entityName}", Created = DateTime.UtcNow, Description = $"{entityName} Successfully Created" },
                new State { Id=Guid.NewGuid(),  Name = $"Update{entityName}", Created = DateTime.UtcNow, Description = $"Update{entityName}" },
                new State { Id=Guid.NewGuid(),  Name = $"Updated{entityName}", Created = DateTime.UtcNow, Description = $"{entityName} Successfully Updated" },
                new State { Id=Guid.NewGuid(),  Name = $"Delete{entityName}", Created = DateTime.UtcNow, Description = $"Delete{entityName}" },
                new State { Id=Guid.NewGuid(),  Name = $"Deleted{entityName}", Created = DateTime.UtcNow, Description = $"{entityName} Successfully Deleted" },
            };

        }
    }
}
