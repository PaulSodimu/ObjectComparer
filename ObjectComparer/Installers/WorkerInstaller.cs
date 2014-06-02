using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ObjectComparer.Formatting;
using ObjectComparer.Workers;

namespace ObjectComparer.Installers
{
    public class WorkerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<PropertyGetter>()
                .WithService.DefaultInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<Auditor>()
                .WithService.DefaultInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<RulesFactory>()
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}
