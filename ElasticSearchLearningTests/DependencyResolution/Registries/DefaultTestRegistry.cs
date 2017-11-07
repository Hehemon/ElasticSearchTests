using ElasticSearchLearningTests.ElasticSearchConfigurations;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using StructureMap;

namespace ElasticSearchLearningTests.DependencyResolution.Registries
{
    class DefaultTestRegistry : Registry
    {
        public DefaultTestRegistry()
        {
            ForSingletonOf<IConnectionConfigurationResolver>().Use<DefaultConnectionConfigurationResolver>();
            ForSingletonOf<IConnectionSettingsResolver>().Use<DefaultConnectionSettingsResolver>();
        }
    }
}
