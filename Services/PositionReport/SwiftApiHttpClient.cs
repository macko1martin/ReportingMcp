namespace ReportingMCP.Services.PositionReport;

public class SwiftApiHttpClient(HttpClient httpClient) : ISwiftApiHttpClient
{
    // SourceFileController GET endpoints
    public async Task<string> GetAllSourceFilesAsync() => await GetAsync("SourceFile/getAll");
    public async Task<string> ResetAllSourceFilesAsync() => await GetAsync("SourceFile/resetAll");
    public async Task<string> UpdateFileNameAsync(string fileId, string newName) => 
        await GetAsync($"SourceFile/updateFileName?fileId={fileId}&newName={newName}");
    public async Task<string> GetCurrentAggregationStatusAsync() => await GetAsync("SourceFile/AggregationStatus");

    private async Task<string> GetAsync(string relativeUrl)
    {
        var response = await httpClient.GetAsync(relativeUrl);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
}