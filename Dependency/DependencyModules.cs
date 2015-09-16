using System.Reflection;
using IoCNinja;

namespace Dependency
{
    public class DependencyModules : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());

            IoC.Modules.Add<Application.ApplicationDependencyModule>();
            IoC.Modules.Add<Data.DataDependencyModule>();
            IoC.Modules.Add<Domain.DomainDependencyModule>();
            IoC.Modules.Add<Presentation.PresentationDependencyModule>();
            IoC.Modules.Add<Reports.ReportsDependencyModule>();
        }
        #endregion
    }
}