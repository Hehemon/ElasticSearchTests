using System;
using ElasticSearchLearningTests.Logging.Interfaces;
using log4net;

namespace ElasticSearchLearningTests.Logging
{
    public class LoggerResolver : ILoggerResolver
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type?.FullName);
        }
    }
}
