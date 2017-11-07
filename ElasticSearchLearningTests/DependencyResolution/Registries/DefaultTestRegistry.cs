using ElasticSearchLearningTests.ElasticSearchConfigurations;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using ElasticSearchLearningTests.Logging;
using ElasticSearchLearningTests.Logging.Interfaces;
using StructureMap;

namespace ElasticSearchLearningTests.DependencyResolution.Registries
{
    class DefaultTestRegistry : Registry
    {
        public DefaultTestRegistry()
        {
            ForSingletonOf<ILoggerResolver>().Use<LoggerResolver>();
            ForSingletonOf<IConnectionConfigurationResolver>().Use<DefaultConnectionConfigurationResolver>();
        }
    }
}
