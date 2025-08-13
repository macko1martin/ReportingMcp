using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;
using ReportingMCP.Services.Balancing;
using ReportingMCP.Services.PositionReport;
using ReportingMCP.Services.Confirmations;

namespace ReportingMCP.Tools;

[McpServerToolType]
public static class ReportingTools
{
    [McpServerTool, Description("Get a list of balancing deals.")]
    public static async Task<string> GetBalancingDeals(IBalancingService balancingService)
    {
        var deals = await balancingService.GetAllDeals();
        
        return JsonSerializer.Serialize(deals);
    }

    [McpServerTool, Description("Get a list of Source Files for reporting.")]
    public static async Task<string> GetReportingSourceFiles(ISwiftService swiftService)
    {
        var sourceFiles = await swiftService.GetAllSourceFiles();

        return JsonSerializer.Serialize(sourceFiles);
    }

    [McpServerTool, Description("Reset source files.")]
    public static async Task ResetSourceFiles(ISwiftService swiftService)
    {
        await swiftService.ResetAllSourceFiles();
    }

    // Confirmation Deals Methods
    [McpServerTool, Description("Get a list of all confirmation deals.")]
    public static async Task<string> GetConfirmationDeals(IConfirmationService confirmationService)
    {
        var deals = await confirmationService.GetAllDeals();
        
        return JsonSerializer.Serialize(deals);
    }

    [McpServerTool, Description("Get a specific confirmation deal by ID.")]
    public static async Task<string> GetConfirmationDealById(IConfirmationService confirmationService, string id)
    {
        var deal = await confirmationService.GetDealById(id);
        
        return JsonSerializer.Serialize(deal);
    }

    [McpServerTool, Description("Get all unique tags from confirmation deals.")]
    public static async Task<string> GetConfirmationDealTags(IConfirmationService confirmationService)
    {
        var tags = await confirmationService.GetAllTags();
        
        return JsonSerializer.Serialize(tags);
    }

    [McpServerTool, Description("Get all linkable confirmation deals.")]
    public static async Task<string> GetLinkableConfirmationDeals(IConfirmationService confirmationService)
    {
        var deals = await confirmationService.GetLinkableDeals();
        
        return JsonSerializer.Serialize(deals);
    }

    [McpServerTool, Description("Create or update a confirmation deal. Provide deal data as JSON string.")]
    public static async Task<string> CreateOrUpdateConfirmationDeal(IConfirmationService confirmationService, string dealData)
    {
        var dealObject = JsonSerializer.Deserialize<object>(dealData);
        var result = await confirmationService.CreateOrUpdateDeal(dealObject!);
        
        return result;
    }

    [McpServerTool, Description("Update multiple confirmation deals. Provide deals data as JSON string.")]
    public static async Task<string> UpdateManyConfirmationDeals(IConfirmationService confirmationService, string dealsData)
    {
        var dealsObject = JsonSerializer.Deserialize<List<object>>(dealsData);
        var result = await confirmationService.UpdateManyDeals(dealsObject!);
        
        return result;
    }

    [McpServerTool, Description("Update deal formula for a confirmation deal. Provide deal data as JSON string.")]
    public static async Task<string> UpdateConfirmationDealFormula(IConfirmationService confirmationService, string dealData)
    {
        var dealObject = JsonSerializer.Deserialize<object>(dealData);
        var result = await confirmationService.UpdateDealFormula(dealObject!);
        
        return result;
    }

    [McpServerTool, Description("Delete a confirmation deal by ID.")]
    public static async Task DeleteConfirmationDeal(IConfirmationService confirmationService, string id)
    {
        await confirmationService.DeleteDealById(id);
    }

    [McpServerTool, Description("Sync end dates for confirmation deals.")]
    public static async Task<string> SyncConfirmationDealEndDates(IConfirmationService confirmationService)
    {
        var result = await confirmationService.SyncEndDates();
        
        return JsonSerializer.Serialize(result);
    }

    [McpServerTool, Description("Export formulas for confirmation deals.")]
    public static async Task ExportConfirmationFormulas(IConfirmationService confirmationService)
    {
        await confirmationService.ExportFormulas();
    }
}
