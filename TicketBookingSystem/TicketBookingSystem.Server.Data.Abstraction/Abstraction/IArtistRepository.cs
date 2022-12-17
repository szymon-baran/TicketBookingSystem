using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Abstraction
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<List<Artist>> GetArtistsAsync(int? musicGenreParam);
    }
}
