namespace Bifrost.Pagination
{
    public interface ICollectionResponse<T>
    {
        List<T> Items { get; init; }
    }
}
