## Usage

### 1. Register the service

```csharp
using Bifrost.DataShaping;

builder.Services.AddScoped<IDataShaper, DataShaper>();
```

---

### 2. Validate requested fields

```csharp
if (!dataShaper.Validate<GodDto>(query.Fields))
{
    return BadRequest();
}
```

---

### 3. Shape a collection

```csharp
var shaped = dataShaper.ShapeCollection(gods, query.Fields);
```

Query example:

```
?fields=name,powerLevel
```

Response example:

```json
{
  "name": "Odin",
  "powerLevel": 9001
}
```

---

### 4. Usage with pagination

```csharp
var result = new PaginationResult<ExpandoObject>
{
    Items = dataShaper.ShapeCollection(gods, query.Fields),
    Page = query.Page,
    PageSize = query.PageSize,
    TotalCount = totalCount
};

return Ok(result);
```
