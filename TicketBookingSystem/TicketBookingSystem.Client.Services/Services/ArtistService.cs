using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using Microsoft.AspNetCore.Components;
using TicketBookingSystem.Shared.Application;

namespace TicketBookingSystem.Client.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly string _api = "api/artist";

        public ArtistService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Artist>? Artists { get; set; } = new();
        public Dictionary<int, string>? ArtistsToSelectList { get; set; } = new();

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

        public async Task<EditArtistVM?> GetArtistToEdit(int id)
        {
            EditArtistVM? artist = await _httpClient.GetFromJsonAsync<EditArtistVM?>(_api + $"/getArtistById?id={id}");
            if (artist != null)
            {
                return artist;
            }

            return null;
        }

        public async Task EditArtist(EditArtistVM model)
        {
            var result = await _httpClient.PutAsJsonAsync(_api + $"/editArtist", model);
            if (result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("artists");
            }
        }

        public async Task GetArtistsToSelectList()
        {
            Dictionary<int, string> dictionary = await _httpClient.GetFromJsonAsync<Dictionary<int, string>>(_api + "/getArtistsToSelectList");
            if (dictionary != null)
                ArtistsToSelectList = dictionary;
        }
    }
}