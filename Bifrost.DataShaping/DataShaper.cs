using System.Collections.Concurrent;
using System.Dynamic;
using System.Reflection;

namespace Bifrost.DataShaping;

public sealed class DataShaper : IDataShaper
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
    
    public ExpandoObject Shape<T>(T source, string? fieldList)
    {
        var properties = ResolveProperties(typeof(T), fieldList);
        IDictionary<string, object?> result = new ExpandoObject();
        
        foreach (var property in properties)
        {
            result[property.Name] = property.GetValue(source);
        }
        
        return (ExpandoObject)result;
    }

    public IReadOnlyList<ExpandoObject> ShapeCollection<T>(IEnumerable<T> sources, string? fieldList)
    {
        var properties = ResolveProperties(typeof(T), fieldList);
        var shapedItems = new List<ExpandoObject>();
        
        foreach (var source in sources)
        {
            IDictionary<string, object?> result = new ExpandoObject();
            
            foreach (var property in properties)
            {
                result[property.Name] = property.GetValue(source);
            }
            
            shapedItems.Add((ExpandoObject)result);
        }
        
        return shapedItems;
    }

    public bool Validate<T>(string? fieldList)
    {
        if (string.IsNullOrWhiteSpace(fieldList))
        {
            return true;
        }
        
        var requestedFields = ParseFieldList(fieldList);
        var availableProperties = GetCachedProperties(typeof(T));
        
        return requestedFields.All(f => 
            availableProperties.Any(p =>
                p.Name.Equals(f, StringComparison.OrdinalIgnoreCase)));
    }
    
    // --- Helpers ---
    private static PropertyInfo[] ResolveProperties(Type type, string? fieldList)
    {
        var availableProperties = GetCachedProperties(type);

        if (string.IsNullOrWhiteSpace(fieldList))
        {
            return availableProperties;
        }
        
        var requestedFields = ParseFieldList(fieldList);
        
        return availableProperties
            .Where(p => requestedFields.Contains(p.Name))
            .ToArray();
    }

    private static PropertyInfo[] GetCachedProperties(Type type) =>
        PropertyCache.GetOrAdd(
            type,
            t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
    
    private static HashSet<string> ParseFieldList(string fieldList) =>
        fieldList.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(f => f.Trim())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
}