using System.Reflection;
using IoCNinja;

namespace Presentation
{
    public class PresentationDependencyModule : IDependencyModule
    {
        #region IDependencyModule Members
        public void ConfigureDependencies(IDependencyConfiguration config)
        {
            IoC.ConfigureFromResolverInterfaces(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}