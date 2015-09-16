using System.Reflection;
using IoCNinja;

namespace StartTestAutomation
{
    public class StartTestAutomationDependencyModule : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}