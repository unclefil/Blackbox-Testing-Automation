using System.Reflection;
using IoCNinja;

namespace Domain
{
    public class DomainDependencyModule : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}
