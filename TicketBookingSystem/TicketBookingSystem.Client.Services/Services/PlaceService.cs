using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using Microsoft.AspNetCore.Components;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared;
using TicketBookingSystem.Client.Abstraction.Helpers;
using System.Text.Json;

namespace TicketBookingSystem.Client.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/place";

        public PlaceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<TicketPurchasePlaceDetailsVM>? PlacesToSelectList { get; set; } = new();


        public async Task GetPlacesToSelectList()
        {
            List<TicketPurchasePlaceDetailsVM> list = await _httpClient.GetFromJsonAsync<List<TicketPurchasePlaceDetailsVM>>(_api + "/getPlacesToSelectList");
            if (list != null)
                PlacesToSelectList = list;
        }
    }
}