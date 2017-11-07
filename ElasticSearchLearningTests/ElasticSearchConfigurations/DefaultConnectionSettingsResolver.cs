using System;
using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using Nest;

namespace ElasticSearchLearningTests.ElasticSearchConfigurations
{
    public class DefaultConnectionSettingsResolver : IConnectionSettingsResolver
    {
        public ConnectionSettings GetConnectionSettings()
        {
            var uri = new Uri(Properties.Settings.Default.ElasticSearchUrl);
            var username = Properties.Settings.Default.ElasticSearchUsername;
            var password = Properties.Settings.Default.ElasticSearchPassword;
            var result = new ConnectionSettings(uri)
                .DefaultIndex("nesttest")
                .BasicAuthentication(username, password);
            return result;
        }
    }
}