using System.Text.Json.Serialization;

namespace ReportingMCP.Models.Reporting;

public record SourceFileResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("filePrefix")]
    public string FilePrefix { get; set; } = string.Empty;

    [JsonPropertyName("filePath")]
    public string FilePath { get; set; } = string.Empty;

    [JsonPropertyName("fileName")]
    public string FileName { get; set; } = string.Empty;

    [JsonPropertyName("isProcessed")]
    public bool IsProcessed { get; set; }

    [JsonPropertyName("isImporting")]
    public bool IsImporting { get; set; }

    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; } = string.Empty;

    [JsonPropertyName("lastProcessedTime")]
    public string LastProcessedTime { get; set; } = string.Empty;

    [JsonPropertyName("lastProcessedLogId")]
    public string LastProcessedLogId { get; set; } = string.Empty;

    [JsonPropertyName("defaultUnit")]
    public VolumeUnitEnum DefaultUnit { get; set; }

    [JsonPropertyName("sourceType")]
    public SourceTypeEnum SourceType { get; set; }

    [JsonPropertyName("granularity")]
    public GranularityEnum Granularity { get; set; }

    [JsonPropertyName("volumeType")]
    public VolumeTypeEnum VolumeType { get; set; }

    // Sets min border for import products
    // e.g -2 imports all products starting 2 months ago and forward
    // e.g 0 imports products from current month forward
    // e.g. 3 imports all product starting 3 months ahead
    [JsonPropertyName("minProductRestriction")]
    public int MinProductRestriction { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter<VolumeUnitEnum>))]
public enum VolumeUnitEnum
{
    THERM,
    KWH,
    MWH,
    GWH,
    M3NLH,
    SM3,
    UNDEFINED
}

[JsonConverter(typeof(JsonStringEnumConverter<SourceTypeEnum>))]
public enum SourceTypeEnum
{
    TRANSPORT,
    COMMODITY,
    STORAGE,
    FUELGAS,
    CAPACITY,
    PERMANENT,
    FUTCOMMODITY,
    FEE,
    UNDEFINED
}

[JsonConverter(typeof(JsonStringEnumConverter<GranularityEnum>))]
public enum GranularityEnum
{
    UNDEFINED,
    DAILY,
    MONTHLY
}

[JsonConverter(typeof(JsonStringEnumConverter<VolumeTypeEnum>))]
public enum VolumeTypeEnum
{
    UNSCHEDULED,
    CONFIRMED,
    BAV,
    BETACONFNOM,
    UNDEFINED
}

[JsonSerializable(typeof(List<SourceFileResponse>))]
internal sealed partial class SourceFileResponseContext : JsonSerializerContext
{

}