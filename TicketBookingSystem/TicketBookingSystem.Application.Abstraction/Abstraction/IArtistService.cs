using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IArtistService
    {
        Task<List<Artist>> GetArtists();
    }
}