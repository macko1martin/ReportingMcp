using ReportingMCP.Models.Balancing;

namespace ReportingMCP.Services
{
    public interface IBalancingService
    {
        Task<List<BalancingDealResponse>> GetAllDeals();
    }
}
