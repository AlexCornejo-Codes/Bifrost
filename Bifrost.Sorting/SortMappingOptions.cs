using Bifrost.Sorting.Abstractions;

namespace Bifrost.Sorting
{
    public sealed class SortMappingOptions
    {
        internal List<ISortMappingDefinition> Mappings { get; } = [];

        public void AddMapping(ISortMappingDefinition mapping)
        {
            Mappings.Add(mapping);
        }
    }
}
