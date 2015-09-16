using System.Reflection;
using IoCNinja;

namespace Data
{
    public class DataDependencyModule : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}