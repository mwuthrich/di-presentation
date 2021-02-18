using MyWebProject;
using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyWebFramework
{
    class Program
    {
        static DependencyInjector _di = new DependencyInjector();

        static void Main(string[] args)
        {
            RegisterControllers(_di);
            ConfigureServices(_di);

            HandleRequest("MyController", "Get");
        }

        static IEnumerable<Type> FindControllers()
        {
            var assembly = Assembly.GetAssembly(typeof(Startup));
            return assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Controller"));
        }

        static void RegisterControllers(DependencyInjector di)
        {
            foreach(var controller in FindControllers())
            {
                di.Register(controller);
            }
        }

        static void ConfigureServices(DependencyInjector di)
        {
            Startup.Configure(di);
        }

        static void HandleRequest(string controllerName, string actionName, params object[] parameters)
        {
            var controllerType = FindControllers().FirstOrDefault(t => t.Name == controllerName);
            var controller = _di.Resolve(controllerType);
            var result = controllerType.InvokeMember(actionName, BindingFlags.InvokeMethod, null, controller, parameters);

            //other HTTP stuff happens here
        }
    }
}
