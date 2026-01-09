using System.Dynamic;

namespace Bifrost.DataShaping
{
    /// <summary>
    /// Provides utilities for dynamically shaping objects
    /// based on a requested list of fields.
    /// </summary>
    public interface IDataShaper
    {
        /// <summary>
        /// Shapes a single source object into a dynamic object
        /// containing only the requested fields.
        /// </summary>
        /// <typeparam name="T">The source object type.</typeparam>
        /// <param name="source">The source object to shape.</param>
        /// <param name="fieldList">
        /// A comma-separated list of field names to include.
        /// If null or empty, all public properties are included.
        /// </param>
        /// <returns>A dynamically shaped object.</returns>
        ExpandoObject Shape<T>(T source, string? fieldList);

        /// <summary>
        /// Shapes a collection of source objects into dynamic objects
        /// containing only the requested fields.
        /// </summary>
        /// <typeparam name="T">The source object type.</typeparam>
        /// <param name="sources">The collection of source objects.</param>
        /// <param name="fieldList">
        /// A comma-separated list of field names to include.
        /// If null or empty, all public properties are included.
        /// </param>
        /// <returns>A collection of dynamically shaped objects.</returns>
        IReadOnlyList<ExpandoObject> ShapeCollection<T>(
            IEnumerable<T> sources,
            string? fieldList);

        /// <summary>
        /// Validates whether all requested fields exist
        /// on the given source type.
        /// </summary>
        /// <typeparam name="T">The source object type.</typeparam>
        /// <param name="fieldList">The requested field list.</param>
        /// <returns>
        /// True if all fields are valid or no fields were provided;
        /// otherwise, false.
        /// </returns>
        bool Validate<T>(string? fieldList);
    }
}
