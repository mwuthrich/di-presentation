using System;

namespace MyWebProject
{
    public class MyController
    {
        private IFinder _finder;
        private ILogger _logger;

        public MyController(IFinder finder, ILogger logger)
        {
            _finder = finder;
            _logger = logger;
        }

        public Item Get()
        {
            return _finder.GetItem();
        }
    }
}
