## Usage

### 1. Register Sorting

```csharp
using Bifrost.Sorting;

builder.Services.AddBifrostSorting(options =>
{
    options.AddMapping(GodMappings.SortMapping);
});
```

---

### 2. Validate sort query

```csharp
if (!sortMappingProvider.ValidateMappings<GodDto, God>(query.Sort))
{
    return BadRequest();
}
```

---

### 3. Apply sorting

```csharp
var sortMappings = sortMappingProvider.GetMappings<GodDto, God>();

var queryable = data
    .AsQueryable()
    .ApplySort(query.Sort, sortMappings);
```

---

### Query example

```
?sort=powerLevel asc
```

---

### Supported format

```
field direction
```

Examples:

```
name asc
powerLevel desc
```
