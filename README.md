Bifrost 🌈

Bifrost is a lightweight .NET toolkit for building clean, flexible REST APIs.

This repository currently provides the DataShaping module, focused on reducing over-fetching by allowing API responses to be dynamically shaped based on a requested list of fields.

Bifrost.DataShaping

Bifrost.DataShaping allows consumers to specify which fields they want to receive, returning dynamic objects that contain only the requested data.

This is especially useful for REST APIs that expose large DTOs but want to give clients control over response size.
