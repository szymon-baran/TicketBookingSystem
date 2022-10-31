using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/event";

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Event>? Events { get; set; } = null;

        public async Task GetEventsList()
        {
            List<Event>? events = await _httpClient.GetFromJsonAsync<List<Event>>(_api);
            if (events != null)
            {
                Events = events;
            }
        }

    }
}