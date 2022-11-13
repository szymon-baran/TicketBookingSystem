using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IArtistService
    {
        List<Artist> Artists { get; set; }
        Task GetArtistsList();
        Task<Artist?> GetArtistById(int id);
    }
}