namespace ReportingMCP.Models.Balancing;

public record FormulaResponse
{
    public string Id { get; init; } = string.Empty;
    public string? FormulaDefinitionId { get; init; }
    public bool IsDefault { get; init; }
    public DateTime? ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public string? Note { get; init; }
    public string? UpdatedBy { get; set; }
    public DateTime? LastUpdated { get; set; }
    public List<VariableResponse>? Variables { get; init; }
    public List<LocationReferenceResponseDto>? LocationReferences { get; init; }
}