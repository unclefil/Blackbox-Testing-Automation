using System;
using Application;
using IoCNinja;

namespace StartTestAutomation
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            IoC.Modules.Add<Dependency.DependencyModules>();

            IoC.Get<IStartApplication>().Start();
        }
    }
}
