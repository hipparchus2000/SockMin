using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Repository
{
    public class RepoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<MapRepo>())
                                .WithService.DefaultInterfaces()
                                .LifestyleSingleton());
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<Repository.Entities.ApplicationSpecific.Booking>())
                                .WithService.DefaultInterfaces()
                                .LifestyleSingleton());
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<Repository.Entities.ConnectionAndState.Connection>())
                                .WithService.DefaultInterfaces()
                                .LifestyleSingleton());
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<Repository.Entities.Generic.Cost> ())
                                .WithService.DefaultInterfaces()
                                .LifestyleSingleton());
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<Repository.Entities.UserAndPermissions.User>())
                                .WithService.DefaultInterfaces()
                                .LifestyleSingleton());
        }
    }
}
