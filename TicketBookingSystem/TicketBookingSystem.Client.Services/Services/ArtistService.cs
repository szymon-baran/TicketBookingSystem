using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using Microsoft.AspNetCore.Components;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared;
using TicketBookingSystem.Client.Abstraction.Helpers;
using System.Text.Json;
using TicketBookingSystem.Shared.Dictionaries;
using System.Net.Http;
using TicketBookingSystem.Client.Abstraction.Utils;

namespace TicketBookingSystem.Client.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly string _api = "api/artist";
        private readonly PublicClient _publicClient;

        public ArtistService(HttpClient httpClient, NavigationManager navigationManager, PublicClient publicClient)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _publicClient = publicClient;
        }

        public Dictionary<int, string>? ArtistsToSelectList { get; set; } = new();

        public Artist Artist = new();

        public async Task<PagingResponse<Artist>> GetArtistsList(PaginationParameters paginationParameters, MusicGenre id = MusicGenre.None)
        {
            var response = await _publicClient.Client.GetAsync(_api + $"/getArtists?pageNumber={paginationParameters.PageNumber}&id={(int)id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var pagingResponse = new PagingResponse<Artist>
            {
                Items = JsonSerializer.Deserialize<List<Artist>>(content),
                MetaData = JsonSerializer.Deserialize<PaginationMetaData>(response.Headers.GetValues("X-Pagination").First())
            };

            return pagingResponse;
            
        }

        public async Task<Artist?> GetArtistById(int id)
        {
            Artist? artist = await _publicClient.Client.GetFromJsonAsync<Artist?>(_api + $"/getArtistById?id={id}");
            if (artist != null)
            {
                return artist;
            }

            return null;
        }

        public async Task<ArtistAddEditVM?> GetArtistToEdit(int id)
        {
            ArtistAddEditVM? artist = await _httpClient.GetFromJsonAsync<ArtistAddEditVM?>(_api + $"/getArtistById?id={id}");
            if (artist != null)
            {
                return artist;
            }

            return null;
        }

        public async Task EditArtist(ArtistAddEditVM model)
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

        public async Task AddArtist(ArtistAddEditVM model)
        {
            var result = await _httpClient.PostAsJsonAsync(_api + "/addArtist", model);
            var response = await result.Content.ReadFromJsonAsync<int?>();

            if (response != null)
            {
                await GetArtistsList(new PaginationParameters(), MusicGenre.None);
                _navigationManager.NavigateTo("artists");
            }

        }

    }
}