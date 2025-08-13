using System.Text.Json.Serialization;

namespace ReportingMCP.Models.Confirmations;

public record DealResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("dealNumber")]
    public string DealNumber { get; set; } = string.Empty;

    [JsonPropertyName("dealType")]
    public string DealType { get; set; } = string.Empty;

    [JsonPropertyName("counterparty")]
    public string Counterparty { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("isConfirmed")]
    public bool IsConfirmed { get; set; }

    [JsonPropertyName("isProcessed")]
    public bool IsProcessed { get; set; }

    [JsonPropertyName("createdTime")]
    public string CreatedTime { get; set; } = string.Empty;

    [JsonPropertyName("updatedTime")]
    public string UpdatedTime { get; set; } = string.Empty;

    [JsonPropertyName("confirmedTime")]
    public string ConfirmedTime { get; set; } = string.Empty;

    [JsonPropertyName("volume")]
    public decimal Volume { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("startDate")]
    public string StartDate { get; set; } = string.Empty;

    [JsonPropertyName("endDate")]
    public string EndDate { get; set; } = string.Empty;

    [JsonPropertyName("deliveryPoint")]
    public string DeliveryPoint { get; set; } = string.Empty;

    [JsonPropertyName("notes")]
    public string Notes { get; set; } = string.Empty;
}
