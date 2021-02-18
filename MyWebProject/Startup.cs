using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebProject
{
    public static class Startup
    {
        public static void Configure(DependencyInjector di)
        {
            di.Register<ILogger, Logger>();
            di.Register<IDatabase, Database>();
            di.Register<IFinder, ItemFinder>();
            di.Register<ISettings, Settings>();
        }
    }
}
