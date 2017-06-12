using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Entities.ApplicationSpecific;
using Repository.Entities.ConnectionAndState;
using Repository.Entities.Html;
using Repository.Entities.UserAndPermissions;
using Repository.Entities.Generic;

namespace Repository
{
    public class SockMinDbContext : DbContext
    {

        public SockMinDbContext() : base("SockMinDbContext")
        {
        }

        //application specific
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ItineraryItem> ItineraryItems { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        //Connection and State
        public DbSet<Connection> Connections { get; set; }
        public DbSet<State> States { get; set; }


        //Generic
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<Price> Prices { get; set; }

        //Html
        public DbSet<Map> Maps { get; set; }
        public DbSet<NavCategory> NavCategories { get; set; }
        public DbSet<NavItem> NavItems { get; set; }
        public DbSet<StatusBarItem> StatusBarItems { get; set; }


        //User and Permissions
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionCategory> PermissionCategories { get; set; }
        public DbSet<ContactPoint> ContactPoints { get; set; }
        public DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            Database.SetInitializer<SockMinDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
