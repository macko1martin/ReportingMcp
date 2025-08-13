using ReportingMCP.Models.Reporting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReportingMCP.Services.PositionReport;
public class SwiftService(ISwiftApiHttpClient swiftApiHttpClient) : ISwiftService
{
    public async Task<List<SourceFileResponse>> GetAllSourceFiles()
    {
        var json = await swiftApiHttpClient.GetAllSourceFilesAsync();
        
        // Add logging to see the raw JSON
        Console.WriteLine($"Raw JSON response: {json}");
        
        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("JSON response is null or empty");
            return [];
        }
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = 
            {
                new JsonStringEnumConverter<VolumeUnitEnum>(),
                new JsonStringEnumConverter<SourceTypeEnum>(),
                new JsonStringEnumConverter<GranularityEnum>(),
                new JsonStringEnumConverter<VolumeTypeEnum>()
            }
        };
        
        try
        {
            var result = JsonSerializer.Deserialize<List<SourceFileResponse>>(json, options);
            Console.WriteLine($"Successfully deserialized {result?.Count ?? 0} source files");
            return result ?? [];
        }
        catch (JsonException ex)
        {
            try
            {
                var fallbackOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var fallbackResult = JsonSerializer.Deserialize<List<SourceFileResponse>>(json, fallbackOptions);

                return fallbackResult ?? [];
            }
            catch (Exception fallbackEx)
            {
                Console.WriteLine($"Fallback deserialization also failed: {fallbackEx.Message}");
            }
            
            return [];
        }
    }

    public async Task ResetAllSourceFiles()
    {
        try
        {
            await swiftApiHttpClient.ResetAllSourceFilesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error resetting source files: {ex.Message}");
            throw;
        }
    }
}
