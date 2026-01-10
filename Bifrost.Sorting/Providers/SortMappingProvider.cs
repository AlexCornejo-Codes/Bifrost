using Bifrost.Sorting.Abstractions;
using Bifrost.Sorting.Definitions;
using Bifrost.Sorting.Models;

namespace Bifrost.Sorting.Providers;

public sealed class SortMappingProvider(IEnumerable<ISortMappingDefinition> sortMappingDefinitions)
{
    public SortMapping[] GetMappings<TSource, TDestination>()
    {
        var definition = sortMappingDefinitions
            .OfType<SortMappingDefinition<TSource, TDestination>>()
            .FirstOrDefault();

        if (definition is null)
        {
            throw new InvalidOperationException(
                $"The sort mapping from '{typeof(TSource).Name}' to '{typeof(TDestination).Name}' is not defined.");
        }
        
        return definition.Mappings;
    }

    public bool ValidateMappings<TSource, TDestination>(string? sort)
    {
        if (string.IsNullOrWhiteSpace(sort))
        {
            return true;
        }
        
        var sortFields = sort
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(f => f.Split(' ')[0])
            .Where(f => !string.IsNullOrWhiteSpace(f));

        var mappings = GetMappings<TSource, TDestination>();
        
        return sortFields.All(f =>
            mappings.Any(m => m.SortField.Equals(f, StringComparison.OrdinalIgnoreCase)));
    }
}