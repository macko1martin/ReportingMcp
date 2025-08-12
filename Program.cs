using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReportingMCP.Services.Balancing;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IBalancingApiHttpClient, BalancingApiHttpClient>((provider, client) =>
{
    const string baseUrl = "https://balancing-api.gpm.aws-eu1.energy.local/";
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddSingleton<IBalancingService, BalancingService>();

await builder.Build().RunAsync();