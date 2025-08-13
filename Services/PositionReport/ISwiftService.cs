using ReportingMCP.Models.Reporting;

namespace ReportingMCP.Services.PositionReport;
public interface ISwiftService
{
    Task<List<SourceFileResponse>> GetAllSourceFiles();
    Task ResetAllSourceFiles();
}
