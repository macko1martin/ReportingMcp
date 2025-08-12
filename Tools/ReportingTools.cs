using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;
using ReportingMCP.Services;

namespace ReportingMCP.Tools;

[McpServerToolType]
public static class ReportingTools
{
    [McpServerTool, Description("Get a list of balancing deals.")]
    public static async Task<string> GetMonkeys(IBalancingService balancingService)
    {
        var monkeys = await balancingService.GetAllDeals();
        
        return JsonSerializer.Serialize(monkeys);
    }
}
