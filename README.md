# Bifrost 🌈

🚀 **Status:** Stable – v1.0

**Bifrost** is a lightweight .NET toolkit for building clean, flexible REST APIs.

The goal of Bifrost is to provide small, explicit, and composable building blocks that solve common API concerns without forcing heavy frameworks or opinionated architectures.

---

## Packages

### 🔹 AC.Bifrost.DataShaping

Allows API consumers to dynamically select which fields they want returned.
This helps reduce over-fetching and keeps responses lightweight.

**Key features:**

* Dynamic field selection via query strings
* Returns shaped dynamic objects
* Framework-agnostic design
* Works seamlessly with DTOs

---

### 🔹 AC.Bifrost.Sorting

Provides a declarative and safe way to apply dynamic sorting to `IQueryable` queries.
Sorting rules are defined explicitly through mappings, avoiding fragile string-based ordering.

**Key features:**

* Dynamic sorting via query strings
* Explicit sort mappings (DTO → Entity)
* Support for multiple fields
* Ascending / descending control
* Compatible with Entity Framework and LINQ providers

> ℹ️ Internally, this package uses `System.Linq.Dynamic.Core` to enable string-based sorting expressions.
> The dependency is included automatically via NuGet—no additional setup is required.

**Design contract:**

* Sorting parameters are expected to be validated before application
* Invalid sort fields fail fast

---

### 🔹 AC.Bifrost.Pagination

Provides simple and explicit models for representing paginated API responses.

This package focuses on describing pagination state without coupling to data access, frameworks, or transport concerns.

**Key features:**

* Simple pagination result model
* Calculated pagination metadata (total pages, navigation flags)
* Framework-agnostic design
* Works with any data source

Pagination is designed to be composed with sorting and data shaping as part of a clean API response pipeline.

---

## Philosophy

Bifrost follows a few simple principles:

* 🧱 Small, composable packages
* 🔍 Explicit configuration over convention
* ⚡ Predictable behavior, zero magic
* 🧪 Easy to test and reason about

Each package can be used independently or combined as part of a larger API pipeline.

---

## Supported frameworks

* .NET 8.0 (LTS)
* .NET 9.0

---

## License

MIT