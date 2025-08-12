using ReportingMCP.Models.Balancing;

namespace ReportingMCP.Services.Balancing
{
    public interface IBalancingService
    {
        Task<List<BalancingDealResponse>> GetAllDeals();
    }
}
