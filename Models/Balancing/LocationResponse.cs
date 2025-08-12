namespace ReportingMCP.Models.Balancing;

public record LocationReferenceResponseDto
{
    public string Id { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public LocationType LocationType { get; init; }
    public FlowDirection FlowDirection { get; init; }
    public bool EnableConsumption { get; init; }
    public bool EnableNegativeOverflow { get; init; }
}

public enum LocationType
{
    Capacity,
    Commodity,
    Deal,
    Invalid
}

public enum FlowDirection
{
    From,
    To
}