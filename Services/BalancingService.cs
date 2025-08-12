using ReportingMCP.Models.Balancing;

namespace ReportingMCP.Services;

public class BalancingService(IBalancingApiHttpClient balancingApiHttpClient) : IBalancingService
{
    public async Task<List<BalancingDealResponse>> GetAllDeals()
    {
        var json = await balancingApiHttpClient.GetAllDealsAsync();

        return System.Text.Json.JsonSerializer.Deserialize<List<BalancingDealResponse>>(json) ?? [];
    }
}
