using System.Threading.Tasks;

namespace ReportingMCP.Services
{
    public interface IBalancingApiHttpClient
    {
        Task<string> GetLatestCalculationAsync();
        Task<string> GetUniqueTagsAsync();
        Task<string> GetDealResultExportAsync();
        Task<string> CreateComparisonCsvAsync();
        Task<string> CreateRiskCsvAsync();
        Task<string> PublishResultsAsync();
        Task<string> NotifyRiskAsync();
        Task<string> GetAllDealsAsync();
        Task<string> GetDealsByStatusesAsync(string statuses);
        Task<string> GetDealByIdAsync(string id);
        Task<string> GetAllReferencesAsync();
        Task<string> SynchronizeDealsAsync();
        Task<string> GetFormulaConfigsAsync();
    }
}
