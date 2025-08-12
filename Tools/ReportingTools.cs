using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ReportingMCP.Tools;

[McpServerToolType]
public static class ReportingTools
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => "Hello from Reporting MCP";
}
