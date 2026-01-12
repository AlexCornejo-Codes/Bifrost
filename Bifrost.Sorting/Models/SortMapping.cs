namespace Bifrost.Sorting.Models;

/// <summary>
/// Defines a mapping between an external sort field (from a query string)
/// and a concrete property on the target model.
/// </summary>
/// <param name="SortField">
/// The field name expected from the client (e.g. "createdAt").
/// </param>
/// <param name="PropertyName">
/// The actual property name on the model used for sorting.
/// </param>
/// <param name="DefaultDescending">
/// Indicates whether the sort should default to descending order
/// when no explicit direction is provided.
/// </param>
public sealed record SortMapping(
    string SortField,
    string PropertyName,
    bool DefaultDescending = false);