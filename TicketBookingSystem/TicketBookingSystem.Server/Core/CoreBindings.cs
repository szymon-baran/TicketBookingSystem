using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Application.Services;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Data.Repositories;

namespace TicketBookingSystem.Server
{
    public static class CoreBindings
    {
        public static IServiceCollection Load(this IServiceCollection services)
        {
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }
    }
}
