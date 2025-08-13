using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReportingMCP.Services.Balancing;
using ReportingMCP.Services.PositionReport;
using ReportingMCP.Services.Confirmations;

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
    client.BaseAddress = new Uri("https://balancing-api.gpm.aws-eu1.energy.local/");
});

builder.Services.AddHttpClient<ISwiftApiHttpClient, SwiftApiHttpClient>((provider, client) =>
{
    client.BaseAddress = new Uri("https://swift-api.gpm.aws-eu1.energy.local/");
});

builder.Services.AddHttpClient<IConfirmationApiHttpClient, ConfirmationApiHttpClient>((provider, client) =>
{
    client.BaseAddress = new Uri("https://confirmation-api.gpm.aws-eu1.energy.local/");
});

builder.Services.AddTransient<IBalancingService, BalancingService>();
builder.Services.AddTransient<ISwiftService, SwiftService>();
builder.Services.AddTransient<IConfirmationService, ConfirmationService>();

var container = builder.Build();

await container.RunAsync();