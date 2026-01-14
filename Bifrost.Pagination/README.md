## Usage

### 1. Create a paginated response

```csharp
var result = new PaginationResult<GodDto>
{
    Items = gods,
    Page = query.Page,
    PageSize = query.PageSize,
    TotalCount = totalCount
};

return Ok(result);
```

---

### Query Example:

```
GET /gods?page=1&pageSize=10
```

### Response format

```json
{
  "items": [],
  "page": 1,
  "pageSize": 10,
  "totalCount": 42,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

---

### Required inputs

* `Items`
* `Page`
* `PageSize`
* `TotalCount`

### Derived automatically:

* `TotalPages`
* `HasPreviousPage`
* `HasNextPage`
