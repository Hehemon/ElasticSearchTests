using System;
using Elasticsearch.Net;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;

namespace ElasticSearchLearningTests.ElasticSearchConfigurations
{
    /// <summary>
    /// Resolver takes data from application properties.
    /// </summary>
    internal class DefaultConnectionConfigurationResolver : IConnectionConfigurationResolver
    {
        public ConnectionConfiguration GetConnectionConfiguration()
        {
            var uri = new Uri(Properties.Settings.Default.ElasticSearchUrl);
            var username = Properties.Settings.Default.ElasticSearchUsername;
            var password = Properties.Settings.Default.ElasticSearchPassword;
            var result = new ConnectionConfiguration(uri)
                .BasicAuthentication(username, password);
            return result;
        }
    }
}
