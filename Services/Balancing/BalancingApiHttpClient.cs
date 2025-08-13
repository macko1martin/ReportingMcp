namespace ReportingMCP.Services.Balancing;

public class BalancingApiHttpClient(HttpClient httpClient) : IBalancingApiHttpClient
{
    // CalculationController
    public async Task<string> GetLatestCalculationAsync() => await GetAsync("Calculation/Latest");
    public async Task<string> GetUniqueTagsAsync() => await GetAsync("Calculation/Tags");
    public async Task<string> GetDealResultExportAsync() => await GetAsync("Calculation/DealResults");
    public async Task<string> CreateComparisonCsvAsync() => await GetAsync("Calculation/ComparisonCsv");
    public async Task<string> CreateRiskCsvAsync() => await GetAsync("Calculation/RiskCsv");
    public async Task<string> PublishResultsAsync() => await GetAsync("Calculation/Publish");
    public async Task<string> NotifyRiskAsync() => await GetAsync("Calculation/NotifyRisk");

    // DealController
    public async Task<string> GetAllDealsAsync() => await GetAsync("Deal/All");
    public async Task<string> GetDealsByStatusesAsync(string statuses) => await GetAsync($"Deal/ByStatus/{statuses}");
    public async Task<string> GetDealByIdAsync(string id) => await GetAsync($"Deal/{id}");

    // ReferencesController
    public async Task<string> GetAllReferencesAsync() => await GetAsync("References/All");
    public async Task<string> SynchronizeDealsAsync() => await GetAsync("References/SynchronizeDeals");

    // FormulaController
    public async Task<string> GetFormulaConfigsAsync() => await GetAsync("Formula/Configs");

    private async Task<string> GetAsync(string relativeUrl)
    {
        var response = await httpClient.GetAsync(relativeUrl);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}