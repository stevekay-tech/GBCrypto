using Blazored.LocalStorage;
using Blazored.Toast;
using GloboCrypto.PWA.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GloboCrypto.PWA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("coinapi");
            builder.Services.AddTransient<IAppSettings, AppSettings>();
            builder.Services.AddTransient<IAppStorageService, AppStorageService>();
            builder.Services.AddScoped<ICoinAPIService, CoinAPIService>();
            await builder.Build().RunAsync();
        }
    }
}
