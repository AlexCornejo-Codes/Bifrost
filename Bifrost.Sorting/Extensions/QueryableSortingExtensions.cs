using Bifrost.Sorting.Models;
using System.Linq.Dynamic.Core;

namespace Bifrost.Sorting.Extensions;

public static class QueryableSortingExtensions
{
    public static IQueryable<T> ApplySort<T>(
        this IQueryable<T> query,
        string? sort,
        SortMapping[] mappings,
        string defaultOrderById = "Id")
    {
        if (string.IsNullOrWhiteSpace(sort))
        {
            return query.OrderBy(defaultOrderById);
        }
        
        string[] sortFields = sort
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var orderByParts = new List<string>();

        foreach (string field in sortFields)
        {
            (string sortField, bool isDescending) = ParseSortField(field);

            SortMapping mapping = mappings.First(m =>
                m.SortField.Equals(sortField, StringComparison.OrdinalIgnoreCase));

            string direction = (isDescending, mapping.DefaultDescending) switch
            {
                (false, false) => "ASC",
                (false, true)  => "DESC",
                (true, false)  => "DESC",
                (true, true)   => "ASC"
            };

            orderByParts.Add($"{mapping.PropertyName} {direction}");
        }

        string orderBy = string.Join(", ", orderByParts);

        return query.OrderBy(orderBy);
    }
    
    private static (string SortField, bool IsDescending) ParseSortField(string field)
    {
        string[] parts = field.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string sortField = parts[0];
        bool isDescending =
            parts.Length > 1 &&
            parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

        return (sortField, isDescending);
    }
    
    
}