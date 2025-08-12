using System.Text.Json.Serialization;

namespace ReportingMCP.Models.Balancing;

public record BalancingDealResponse
{
    public string Id { get; init; } = string.Empty;
    public long EndurId { get; init; }
    public int Priority { get; init; }
    public string? Note { get; init; }
    public string? InstrumentType { get; init; }
    public IEnumerable<string>? Tags { get; init; }
    public string Description { get; init; } = string.Empty;
    public bool IsMissing { get; init; }
    public DateTime? ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public bool SyncDealValidity { get; init; }
    public DealStatus DealStatus { get; init; }
    public IEnumerable<FormulaResponse> Formulas { get; init; } = new List<FormulaResponse>();
}

public enum DealStatus
{
    New,
    Calculated,
    Default,
    Ignored
}

[JsonSerializable(typeof(List<BalancingDealResponse>))]
internal sealed partial class BalancingDealResponseContext : JsonSerializerContext
{

}