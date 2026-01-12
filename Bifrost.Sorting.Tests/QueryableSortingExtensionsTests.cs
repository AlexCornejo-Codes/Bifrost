using Bifrost.Sorting.Extensions;
using Bifrost.Sorting.Models;

namespace Bifrost.Sorting.Tests;

public sealed class QueryableSortingExtensionsTests
{
    private static IQueryable<TestModel> CreateQuery() =>
    new List<TestModel>
        {
            new() {Id = 3, Name = "Thor", CreatedAt = DateTime.Now },
            new() {Id = 1, Name = "Loki", CreatedAt = DateTime.Now.AddDays(-1) },
            new() {Id = 2, Name = "Odin", CreatedAt = DateTime.Now.AddDays(-2) }
        }
    .AsQueryable();

    private static SortMapping[] CreateMappings() =>
        [
            new SortMapping("id", nameof(TestModel.Id)),
            new SortMapping("name", nameof(TestModel.Name)),
            new SortMapping("createdAt", nameof(TestModel.CreatedAt), DefaultDescending: true)
        ];

    [Fact]
    public void ApplySort_WhenSortIsNull_UsesDefaultOrder()
    {
        var query = CreateQuery();
        
        var result = query
            .ApplySort(null, CreateMappings(), defaultOrderById: "Id")
            .ToList();
        
        Assert.Equal([1,2,3], result.Select(x => x.Id));
    }
    
    [Fact]
    public void ApplySort_SortsBySingleField()
    {
        var query = CreateQuery();

        var result = query
            .ApplySort("name", CreateMappings())
            .ToList();

        Assert.Equal(["Loki", "Odin", "Thor"], result.Select(x => x.Name));
    }
    
    [Fact]
    public void ApplySort_SortsDescending()
    {
        var query = CreateQuery();

        var result = query
            .ApplySort("name desc", CreateMappings())
            .ToList();

        Assert.Equal(["Thor", "Odin", "Loki"], result.Select(x => x.Name));
    }
    
    [Fact]
    public void ApplySort_SortsMultipleFields()
    {
        var query = CreateQuery();
        
        var result = query
            .ApplySort("createdAt, name", CreateMappings())
            .ToList();

        Assert.Equal(
            [3, 1, 2],
            result.Select(x => x.Id));
    }
    
    [Fact]
    public void ApplySort_IgnoresInvalidFields()
    {
        var query = CreateQuery();
        
        Assert.Throws<InvalidOperationException>(() =>
            query.ApplySort("invalidField", CreateMappings()).ToList());
    }
}