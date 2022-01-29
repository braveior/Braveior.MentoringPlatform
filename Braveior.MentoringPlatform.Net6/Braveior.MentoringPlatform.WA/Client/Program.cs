using Blazored.LocalStorage;
using Braveior.MentoringPlatform.WA.Client.Providers;
using Braveior.MentoringPlatform.WA.Client.Services;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.WA.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //Adds the dependency injection for the LoginService and Singleton instance for HttpClient
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddHttpClient<ILoginService, LoginService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
            builder.Services.AddHttpClient<IKanboardService, KanboardService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
            builder.Services.AddHttpClient<IStoryService, StoryService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
            builder.Services.AddHttpClient<IProfileService, ProfileService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
            builder.Services.AddHttpClient<IVideoBookService, VideoBookService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });
            builder.Services.AddHttpClient<IWebinarService, WebinarService>(sp => { sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); });



            //Adds the LocalStorage support to Blazor
            builder.Services.AddBlazoredLocalStorage();
            //Adds the Authorization support to Blazor
            builder.Services.AddAuthorizationCore();
            //Adds the Authentication State Provider Support
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //Adds the Fluxor State Management support to Blazor
            builder.Services.AddFluxor(o => o
            .ScanAssemblies(typeof(Program).Assembly).UseRouting());
            //Adds the Mud Blazor support to Blazor
            builder.Services.AddMudServices();
            builder.Services.AddApiAuthorization();



            await builder.Build().RunAsync();
        }
    }
}
