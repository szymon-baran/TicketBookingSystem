using TicketBookingSystem.Client.Abstraction.Helpers;
using TicketBookingSystem.Shared;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IArtistService
    {
        Dictionary<int, string>? ArtistsToSelectList { get; set; }
        Task<PagingResponse<Artist>> GetArtistsList(PaginationParameters paginationParameters, MusicGenre id = MusicGenre.None);
        Task<Artist?> GetArtistById(int id);
        Task<ArtistAddEditVM?> GetArtistToEdit(int id);
        Task EditArtist(ArtistAddEditVM model);
        Task GetArtistsToSelectList();
        Task AddArtist(ArtistAddEditVM model);
    }
}