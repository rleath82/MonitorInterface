using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonitorInterface.Client.Brokers.API;
using MonitorInterface.Client.Brokers.Logging;
using MonitorInterface.Client.Services.Jobs;
using MonitorInterface.Client.Services.Modals;
using MonitorInterface.Client.Services.RunTimes;
using MonitorInterface.Client.Services.ServiceManager;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitorInterface.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMatBlazor();
            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.TopCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 100;
                config.VisibleStateDuration = 5000;
                config.ShowProgressBar = false;
            });
            builder.Services.AddScoped<IApiBroker, ApiBroker>();
            builder.Services.AddScoped<ILogger, Logger<LoggingBroker>>();
            builder.Services.AddScoped<ILoggingBroker, LoggingBroker>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IRunTimeService, RunTimeService>();
            builder.Services.AddScoped<IServiceManagerService, ServiceManagerService>();
            builder.Services.AddScoped<IModalService, ModalService>();


            await builder.Build().RunAsync();
        }
    }
}
