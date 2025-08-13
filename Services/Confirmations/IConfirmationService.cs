using ReportingMCP.Models.Confirmations;

namespace ReportingMCP.Services.Confirmations;

public interface IConfirmationService
{
    // Basic deal operations
    Task<List<DealResponse>> GetAllDeals();
    Task<DealResponse?> GetDealById(string id);
    Task<List<string>> GetAllTags();
    Task<List<DealResponse>> GetLinkableDeals();
    
    // Deal creation and updates
    Task<string> CreateOrUpdateDeal(object deal);
    Task<string> UpdateManyDeals(List<object> deals);
    Task<string> UpdateDealFormula(object deal);
    
    // Administrative operations
    Task DeleteDealById(string id);
    Task<List<object>> SyncEndDates();
    Task ExportFormulas();
}
