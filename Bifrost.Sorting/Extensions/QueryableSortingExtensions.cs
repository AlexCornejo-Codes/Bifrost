using Bifrost.Sorting.Models;
using System.Linq.Dynamic.Core;

namespace Bifrost.Sorting.Extensions;

/// <summary>
/// Provides extension methods for applying dynamic sorting to <see cref="IQueryable{T}"/> instances.
/// </summary>
public static class QueryableSortingExtensions
{
    /// <summary>
    /// Applies dynamic sorting to the query based on a sort string and predefined mappings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the query.
    /// </typeparam>
    /// <param name="query">
    /// The query to which sorting will be applied.
    /// </param>
    /// <param name="sort">
    /// A comma-separated list of sort fields.
    /// Example: <c>"createdAt, name desc"</c>.
    /// </param>
    /// <param name="mappings">
    /// The set of allowed sort mappings that define which fields can be sorted
    /// and how they map to actual model properties.
    /// </param>
    /// <param name="defaultOrderById">
    /// The default property name used for sorting when <paramref name="sort"/> is null or empty.
    /// </param>
    /// <returns>
    /// An <see cref="IQueryable{T}"/> with the specified sorting applied.
    /// </returns>
    /// <remarks>
    /// This method assumes that the <paramref name="sort"/> parameter has already been validated.
    /// If an invalid sort field is provided, an <see cref="InvalidOperationException"/> may be thrown.
    /// </remarks>
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
    
    /// <summary>
    /// Parses an individual sort field into its name and direction.
    /// </summary>
    /// <param name="field">
    /// The raw sort field string (e.g. <c>"name desc"</c>).
    /// </param>
    /// <returns>
    /// A tuple containing the sort field name and a flag indicating descending order.
    /// </returns>
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