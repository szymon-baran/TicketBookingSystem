using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TicketBookingSystem.Client;
using TicketBookingSystem.Client.Abstraction;
using TicketBookingSystem.Client.Services;

namespace TicketBookingSystem.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("TicketBookingSystem.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TicketBookingSystem.ServerAPI"));

            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IArtistService, ArtistService>();

            builder.Services.AddApiAuthorization();

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}