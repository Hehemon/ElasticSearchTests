using ElasticSearchLearningTests.DependencyResolution;
using StructureMap;

namespace ElasticSearchLearningTests.Tests
{
    /// <summary>
    /// Base class for test classes with dependency resolution
    /// </summary>
    public abstract class BaseDependencyResolutionTests
    {
        protected readonly Container Container;

        protected BaseDependencyResolutionTests()
        {
            Container = IoC.GetContainer();
        }
    }
}
