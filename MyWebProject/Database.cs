using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebProject
{
    public interface IDatabase
    {

    }

    public class Database : IDatabase
    {
        private ISettings _settings;
        private ILogger _logger;

        public Database(ISettings settings, ILogger logger)
        {
            _settings = settings;
            _logger = logger;
        }
    }
}
