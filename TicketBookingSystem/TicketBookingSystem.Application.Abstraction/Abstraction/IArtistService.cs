using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IArtistService
    {
        Task<Artist> GetArtistById(int id);
        Task<List<Artist>> GetArtists();
        Task<int> AddArtist(Artist artist);
        Task<bool> EditArtist(Artist artist);
        Task<bool> DeleteArtist(int id);
    }
}