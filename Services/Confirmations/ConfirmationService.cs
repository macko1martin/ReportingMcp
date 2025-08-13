using ReportingMCP.Models.Confirmations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReportingMCP.Services.Confirmations;

public class ConfirmationService(IConfirmationApiHttpClient confirmationApiHttpClient) : IConfirmationService
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly JsonSerializerOptions _fallbackOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<List<DealResponse>> GetAllDeals()
    {
        var json = await confirmationApiHttpClient.GetAllDealsAsync();
        
        Console.WriteLine($"Raw JSON response: {json}");
        
        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("JSON response is null or empty");
            return [];
        }
        
        try
        {
            var result = JsonSerializer.Deserialize<List<DealResponse>>(json, _jsonOptions);
            Console.WriteLine($"Successfully deserialized {result?.Count ?? 0} deals");
            return result ?? [];
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Primary deserialization failed: {ex.Message}");
            try
            {
                var fallbackResult = JsonSerializer.Deserialize<List<DealResponse>>(json, _fallbackOptions);
                return fallbackResult ?? [];
            }
            catch (Exception fallbackEx)
            {
                Console.WriteLine($"Fallback deserialization also failed: {fallbackEx.Message}");
                return [];
            }
        }
    }

    public async Task<DealResponse?> GetDealById(string id)
    {
        try
        {
            var json = await confirmationApiHttpClient.GetDealByIdAsync(id);
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            
            return JsonSerializer.Deserialize<DealResponse>(json, _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting deal by id {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<List<string>> GetAllTags()
    {
        try
        {
            var json = await confirmationApiHttpClient.GetAllTagsAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return [];
            }
            
            return JsonSerializer.Deserialize<List<string>>(json, _jsonOptions) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting tags: {ex.Message}");
            return [];
        }
    }

    public async Task<List<DealResponse>> GetLinkableDeals()
    {
        try
        {
            var json = await confirmationApiHttpClient.GetLinkableDealsAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return [];
            }
            
            return JsonSerializer.Deserialize<List<DealResponse>>(json, _jsonOptions) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting linkable deals: {ex.Message}");
            return [];
        }
    }

    public async Task<string> CreateOrUpdateDeal(object deal)
    {
        try
        {
            var dealJson = JsonSerializer.Serialize(deal, _jsonOptions);
            return await confirmationApiHttpClient.CreateOrUpdateDealAsync(dealJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating/updating deal: {ex.Message}");
            throw;
        }
    }

    public async Task<string> UpdateManyDeals(List<object> deals)
    {
        try
        {
            var dealsJson = JsonSerializer.Serialize(deals, _jsonOptions);
            return await confirmationApiHttpClient.UpdateManyDealsAsync(dealsJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating many deals: {ex.Message}");
            throw;
        }
    }

    public async Task<string> UpdateDealFormula(object deal)
    {
        try
        {
            var dealJson = JsonSerializer.Serialize(deal, _jsonOptions);
            return await confirmationApiHttpClient.UpdateDealFormulaAsync(dealJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating deal formula: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteDealById(string id)
    {
        try
        {
            await confirmationApiHttpClient.DeleteDealByIdAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting deal {id}: {ex.Message}");
            throw;
        }
    }

    public async Task<List<object>> SyncEndDates()
    {
        try
        {
            var json = await confirmationApiHttpClient.SyncEndDatesAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return [];
            }
            
            return JsonSerializer.Deserialize<List<object>>(json, _jsonOptions) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error syncing end dates: {ex.Message}");
            throw;
        }
    }

    public async Task ExportFormulas()
    {
        try
        {
            await confirmationApiHttpClient.ExportFormulasAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exporting formulas: {ex.Message}");
            throw;
        }
    }
}
