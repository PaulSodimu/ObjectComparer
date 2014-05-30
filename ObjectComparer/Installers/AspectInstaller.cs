using System;
using Castle.DynamicProxy;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ObjectComparer.Logging;

namespace ObjectComparer.Installers
{
    public class AspectInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());

            container.Register(Component.For<IInterceptor>().ImplementedBy<LoggingAspect>()); 
        }
    }
}
