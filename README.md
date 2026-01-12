# Bifrost 🌈

🚧 **Status:** Active development (preview)

**Bifrost** is a lightweight .NET toolkit for building clean, flexible REST APIs.

The goal of Bifrost is to provide small, focused building blocks that solve common API problems without forcing a heavy framework or opinionated architecture.

---

## Packages

### 🔹 AC.Bifrost.DataShaping

Allows API consumers to dynamically select which fields they want returned.
This helps reduce over-fetching and keeps responses lightweight.

**Use cases:**

* Partial responses
* Client-driven projections
* Large DTO optimization

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

**Design contract:**

* Sorting parameters are expected to be validated before application
* Invalid sort fields fail fast

---

## Philosophy

Bifrost follows a few simple principles:

* 🧱 Small, composable packages
* 🔍 Explicit configuration over convention
* ⚡ Zero magic, predictable behavior
* 🧪 Easy to test and reason about

Each package can be used independently or combined as part of a larger API pipeline.

---

## Supported frameworks

* .NET 8.0 (LTS)
* .NET 9.0

---

## License

MIT
