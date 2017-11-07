using Nest;

namespace ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces
{
    public interface IConnectionSettingsResolver
    {
        ConnectionSettings GetConnectionSettings();
    }
}