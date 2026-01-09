namespace Bifrost.DataShaping.Tests;

public sealed class TestModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; init; }
}