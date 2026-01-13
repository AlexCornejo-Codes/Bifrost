namespace Bifrost.Pagination.Tests;

public sealed class PaginationResultTests
{
    [Fact]
    public void TotalPages_IsCalculatedCorrectly()
    {
        var result = new PaginationResult<TestModel>()
        {
            Items = [],
            Page = 1,
            PageSize = 10,
            TotalCount = 95
        };
        
        Assert.Equal(10, result.TotalPages);
    }

    [Fact]
    public void TotalItems_IsCalculatedCorrectly()
    {
        var result = new PaginationResult<TestModel>
        {
            Items = [],
            Page = 1,
            PageSize = 10,
            TotalCount = 95
        };
        
        Assert.Equal(95, result.TotalCount);
    }

    [Fact]
    public void HasPreviousPage_IsFalseOnPreviousPage()
    {
        var result = new PaginationResult<TestModel>()
        {
            Items = [],
            Page = 1,
            PageSize = 10,
            TotalCount = 50
        };
        
        Assert.False(result.HasPreviousPage);
    }
    
    [Fact]
    public void HasPreviousPage_IsTrueWhenPageIsGreaterThanOne()
    {
        var result = new PaginationResult<TestModel>
        {
            Items = [],
            Page = 2,
            PageSize = 10,
            TotalCount = 50
        };

        Assert.True(result.HasPreviousPage);
    }
    
    [Fact]
    public void HasNextPage_IsTrueWhenMorePagesExist()
    {
        var result = new PaginationResult<TestModel>
        {
            Items = [],
            Page = 1,
            PageSize = 10,
            TotalCount = 25
        };

        Assert.True(result.HasNextPage);
    }
    
    [Fact]
    public void HasNextPage_IsFalseOnLastPage()
    {
        var result = new PaginationResult<TestModel>
        {
            Items = [],
            Page = 3,
            PageSize = 10,
            TotalCount = 30
        };

        Assert.False(result.HasNextPage);
    }
    
    [Fact]
    public void TotalPages_IsZeroWhenPageSizeIsZero()
    {
        var result = new PaginationResult<TestModel>
        {
            Items = [],
            Page = 1,
            PageSize = 0,
            TotalCount = 100
        };

        Assert.Equal(0, result.TotalPages);
        Assert.False(result.HasNextPage);
    }
}