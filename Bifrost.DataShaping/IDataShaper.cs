using System.Dynamic;

namespace Bifrost.DataShaping
{
    public interface IDataShaper
    {
        ExpandoObject Shape<T>(T source, string? fieldList);
        
        IReadOnlyList<ExpandoObject> ShapeCollection<T>(
            IEnumerable<T> sources,
            string? fieldList);

        bool Validate<T>(string? fieldList);
    }
}
