namespace ReportingMCP.Services.Confirmations;

public interface IConfirmationApiHttpClient
{
    // GET endpoints from actual DealsController
    Task<string> GetAllDealsAsync();
    Task<string> GetDealByIdAsync(string id);
    Task<string> GetAllTagsAsync();
    Task<string> GetLinkableDealsAsync();
    Task<string> SyncEndDatesAsync();
    Task ExportFormulasAsync();
    
    // POST endpoints from actual DealsController
    Task<string> CreateOrUpdateDealAsync(string dealData);
    Task<string> UpdateManyDealsAsync(string dealsData);
    Task<string> UpdateDealFormulaAsync(string dealData);
    
    // DELETE endpoints from actual DealsController
    Task DeleteDealByIdAsync(string id);
}
