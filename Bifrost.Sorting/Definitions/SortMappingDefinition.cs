using Bifrost.Sorting.Abstractions;
using Bifrost.Sorting.Models;

namespace Bifrost.Sorting.Definitions;

public sealed class SortMappingDefinition<TSource, TDestination> : ISortMappingDefinition
{
    public required SortMapping[] Mappings { get; init; }
}