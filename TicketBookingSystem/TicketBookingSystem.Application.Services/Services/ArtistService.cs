using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Artist> GetArtistById(int id)
        {
            Artist artist = await _artistRepository.GetByIdAsync(id);

            return artist;
        }

        public async Task<List<Artist>> GetArtists()
        {
            IEnumerable<Artist> artists = await _artistRepository.GetAllAsync();

            return artists.ToList();
        }

        public async Task<int> AddArtist(Artist artist)
        {
            _artistRepository.Add(artist);
            await _artistRepository.SaveAsync();

            int addedArtistId = artist.Id;

            return addedArtistId;
        }

        public async Task<bool> EditArtist(Artist artist, int id)
        {
            Artist artistToUpdate = await _artistRepository.GetByIdAsync(id);

            artistToUpdate.FirstName = artist.FirstName;
            artistToUpdate.LastName = artist.LastName;
            artistToUpdate.NickName = artist.NickName;
            artistToUpdate.Description = artist.Description;
            artistToUpdate.PhotoUrl = artist.PhotoUrl;
            artistToUpdate.SpotifyUrl = artist.SpotifyUrl;
            artistToUpdate.PrimaryMusicGenre = artist.PrimaryMusicGenre;
            artistToUpdate.SecondaryMusicGenre = artist.SecondaryMusicGenre;
            artistToUpdate.AverageFanbaseAge = artist.AverageFanbaseAge;

            bool result = await _artistRepository.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteArtist(int id)
        {
            Artist artistToDelete = await _artistRepository.GetByIdAsync(id);
            _artistRepository.Remove(artistToDelete);

            bool result = await _artistRepository.SaveAsync();

            return result;
        }
    }
}
