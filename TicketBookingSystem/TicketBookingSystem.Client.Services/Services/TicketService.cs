using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using TicketBookingSystem.Shared.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace TicketBookingSystem.Client.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/ticket";
        private readonly NavigationManager _navigationManager;

        public TicketService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Ticket>? Tickets { get; set; } = null;

        public async Task BuyTicket(BuyOperationVM model)
        {
            var result = await _httpClient.PostAsJsonAsync(_api, model);
            var response = await result.Content.ReadFromJsonAsync<int>();
            if (response != null)
            {
                _navigationManager.NavigateTo("events");
            }
        }
    }
}