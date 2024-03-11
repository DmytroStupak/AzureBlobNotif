using AzureBlobNotif;
using AzureBlobNotif.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<IUriSasGener, UriSasGener>();
        services.AddSingleton<IGmail, Gmail>();
    })
    .Build();

host.Run();
