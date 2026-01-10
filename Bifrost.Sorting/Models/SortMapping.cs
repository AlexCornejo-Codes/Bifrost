namespace Bifrost.Sorting.Models;

public sealed record SortMapping(
    string SortField,
    string PropertyName,
    bool DefaultDescending = false);