using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Artist>> GetArtists()
        {
            List<Artist> artists = await _context.Artists.ToListAsync();

            return artists;
        }
    }
}
