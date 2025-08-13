namespace ReportingMCP.Services.PositionReport;

public interface ISwiftApiHttpClient
{
    Task<string> GetAllSourceFilesAsync();
    Task<string> ResetAllSourceFilesAsync();
    Task<string> UpdateFileNameAsync(string fileId, string newName);
    Task<string> GetCurrentAggregationStatusAsync();
}