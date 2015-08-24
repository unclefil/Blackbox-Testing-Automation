using System.Reflection;
using IoCNinja;

namespace Domain
{
    public class ApplicationDependencyModule : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}
