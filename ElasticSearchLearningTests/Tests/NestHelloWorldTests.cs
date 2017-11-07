using ElasticSearchLearningTests.ElasticSearchConfigurations.Interfaces;
using ElasticSearchLearningTests.Models;
using Nest;
using Xunit;
using Xunit.Abstractions;

namespace ElasticSearchLearningTests.Tests
{
    /// <summary>
    /// For those test should be available ElasticSearch server
    /// </summary>
    public class NestHelloWorldTests : BaseDependencyResolutionTests
    {
        private readonly ConnectionSettings _defaultConfiguration;
        private readonly ITestOutputHelper _output;

        public NestHelloWorldTests(ITestOutputHelper output)
        {
            this._output = output;
            _defaultConfiguration = Container.GetInstance<IConnectionSettingsResolver>().GetConnectionSettings();
        }

        [Fact]
        public async void HelloWorld()
        {
            var client = new ElasticClient(_defaultConfiguration);
            var person = new Person
            {
                Id = 1,
                FirstName = "Hello",
                LastName = "World",
            };
            var response = await client.IndexAsync(person);
            _output.WriteLine($"Response: {response.DebugInformation}");
            Assert.True(response.IsValid);
        }

        [Fact]
        public async void WriteAndDeleteSuccess()
        {
            var client = new ElasticClient(_defaultConfiguration);
            var person = new Person
            {
                FirstName = "Hello",
                LastName = "World",
            };
            var response = await client.IndexAsync(person);
            _output.WriteLine($"Response: {response.DebugInformation}");
            Assert.True(response.IsValid);

            var deleteResponse = client.Delete(new DeleteRequest("nesttest", "person", "0"));
            _output.WriteLine($"DeleteResponse: {response.DebugInformation}");
            Assert.True(deleteResponse.IsValid);
        }

        [Fact]
        public void WriteAndSearchSuccess()
        {
            var client = new ElasticClient(_defaultConfiguration);
            var person = new Person
            {
                Id = 15,
                FirstName = "SearchMe",
                LastName = "SearchMe",
            };
            var response = client.Index(person);
            _output.WriteLine($"Response: {response.DebugInformation}");
            Assert.True(response.IsValid);

            var searchResponse = client.Search<Person>(s => s
                .AllIndices()
                .AllTypes()
                .From(0)
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.FirstName)
                        .Query("SearchMe")
                 )));

            _output.WriteLine($"SearchResponse: {searchResponse.DebugInformation}");
            Assert.True(searchResponse.IsValid);
            Assert.Equal(1, searchResponse.Hits.Count);
        }
    }
}