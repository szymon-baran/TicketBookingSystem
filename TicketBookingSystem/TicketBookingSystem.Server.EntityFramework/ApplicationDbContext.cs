using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Sockets;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.EntityFramework
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<Ticket> Tickets { get; set; }
    }
}