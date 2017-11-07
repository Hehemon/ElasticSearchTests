using System;
using log4net;

namespace ElasticSearchLearningTests.Logging.Interfaces
{
    public interface ILoggerResolver
    {
        ILog GetLogger(Type type);
    }
}
