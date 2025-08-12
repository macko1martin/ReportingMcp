namespace ReportingMCP.Models.Balancing;

public record VariableResponse
{
    public string Id { get; init; } = string.Empty;
    public FormulaVariableType VariableType { get; init; }
    public string ReferenceValue { get; init; } = string.Empty;
    public string ReferenceDisplayName { get; init; } = string.Empty;
}

public enum FormulaVariableType
{
    Numeric,
    Deal,
    Commodity,
    Capacity,
    Constant,
    Missing
}