using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace TicketBookingSystem.Client.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/artist";

        public ArtistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Artist>? Artists { get; set; } = new();

        public Artist Artist = new();

        public async Task GetArtistsList()
        {
            List<Artist>? artists = await _httpClient.GetFromJsonAsync<List<Artist>>(_api + "/getArtists");
            if (artists != null)
            {
                Artists = artists;
            }
        }

        public async Task<Artist?> GetArtistById(int id)
        {
            Artist? artist = await _httpClient.GetFromJsonAsync<Artist?>(_api + $"/getArtistById?id={id}");
            if (artist != null)
            {
                return artist;
            }

            return null;
        }

    }
}