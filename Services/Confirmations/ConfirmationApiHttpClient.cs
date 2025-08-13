namespace ReportingMCP.Services.Confirmations;

public class ConfirmationApiHttpClient(HttpClient httpClient) : IConfirmationApiHttpClient
{
    // GET endpoints matching actual DealsController
    public async Task<string> GetAllDealsAsync() => await GetAsync("api/Deals");
    
    public async Task<string> GetDealByIdAsync(string id) => await GetAsync($"api/Deals/{id}");
    
    public async Task<string> GetAllTagsAsync() => await GetAsync("api/Deals/Tags");
    
    public async Task<string> GetLinkableDealsAsync() => await GetAsync("api/Deals/Linkable");
    
    public async Task<string> SyncEndDatesAsync() => await GetAsync("api/Deals/EndDates/Sync");
    
    public async Task ExportFormulasAsync() => await GetAsync("api/Deals/Formula/Export");
    
    // POST endpoints matching actual DealsController
    public async Task<string> CreateOrUpdateDealAsync(string dealData) => 
        await PostAsync("api/Deals/CreateOrUpdate", dealData);
    
    public async Task<string> UpdateManyDealsAsync(string dealsData) => 
        await PostAsync("api/Deals/UpdateMany", dealsData);
    
    public async Task<string> UpdateDealFormulaAsync(string dealData) => 
        await PostAsync("api/Deals/Formula/Update", dealData);
    
    // DELETE endpoints matching actual DealsController
    public async Task DeleteDealByIdAsync(string id) => await DeleteAsync($"api/Deals/{id}");

    private async Task<string> GetAsync(string relativeUrl)
    {
        var response = await httpClient.GetAsync(relativeUrl);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
    
    private async Task<string> PostAsync(string relativeUrl, string jsonContent)
    {
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(relativeUrl, content);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
    
    private async Task DeleteAsync(string relativeUrl)
    {
        var response = await httpClient.DeleteAsync(relativeUrl);
        response.EnsureSuccessStatusCode();
    }
}
