using ElasticSearchLearningTests.DependencyResolution.Registries;
using StructureMap;

namespace ElasticSearchLearningTests.DependencyResolution
{
    public static class IoC
    {
        public static Container GetContainer()
        {
            return new Container(new DefaultTestRegistry());
        }
    }
}
