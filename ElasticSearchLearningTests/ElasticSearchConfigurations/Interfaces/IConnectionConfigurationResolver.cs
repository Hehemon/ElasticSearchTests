using Elasticsearch.Net;

namespace ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces
{
    public interface IConnectionConfigurationResolver
    {
        ConnectionConfiguration GetConnectionConfiguration();
    }
}
