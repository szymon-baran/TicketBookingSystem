using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Artist>> GetArtistsAsync(int? musicGenreParam)
        {
            List<Artist> artists = await _context.Artists.ToListAsync();

            if (musicGenreParam != null)
            {
                MusicGenre musicGenre = (MusicGenre)musicGenreParam;
                artists = artists.Where(x => musicGenre == MusicGenre.None || x.PrimaryMusicGenre == musicGenre || x.SecondaryMusicGenre == musicGenre).ToList();
            }

            return artists;
        }
    }
}
