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
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
