﻿using TicketBookingSystem.Client.Abstraction;
using System.Net.Http.Json;
using TicketBookingSystem.Shared.Domain;
using TicketBookingSystem.Shared.Application;
using Microsoft.AspNetCore.Components;

namespace TicketBookingSystem.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api = "api/event";
        private readonly NavigationManager _navigationManager;

        public EventService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Event>? Events { get; set; } = null;
        public EventAddEditVM Event { get; set; }

        public async Task GetEventsList()
        {
            List<Event>? events = await _httpClient.GetFromJsonAsync<List<Event>>(_api);
            if (events != null)
            {
                Events = events;
            }
        }

        public async Task AddEvent(EventAddEditVM model)
        {
            var result = await _httpClient.PostAsJsonAsync(_api, model);
            var response = await result.Content.ReadFromJsonAsync<Event>();
            if (response != null)
            {
                await GetEventsList();
                _navigationManager.NavigateTo("events");
            }
        }

        public async Task<EventAddEditVM> GetEventDetails(int id)
        {
            EventAddEditVM? model = await _httpClient.GetFromJsonAsync<EventAddEditVM>($"{_api}/{id}");
            if (model != null)
                return model;
            throw new Exception("Nie znaleziono wydarzenia");
        }

        public async Task<TicketPurchaseEventDetailsVM> GetEventDetailsForTicketPurchase(int id)
        {
            TicketPurchaseEventDetailsVM? model = await _httpClient.GetFromJsonAsync<TicketPurchaseEventDetailsVM>($"{_api}/purchaseDetails/{id}");
            if (model != null)
                return model;
            throw new Exception("Nie znaleziono wydarzenia");
        }

        public async Task EditEvent(EventAddEditVM model)
        {
            var result = await _httpClient.PutAsJsonAsync(_api, model);
            var response = await result.Content.ReadFromJsonAsync<Event>();
            if (response != null)
            {
                await GetEventsList();
                _navigationManager.NavigateTo("events");
            }
        }

        public async Task DeleteEvent(int id)
        {
            var result = await _httpClient.DeleteAsync($"{_api}/{id}");
            var response = await result.Content.ReadFromJsonAsync<int>();
            await GetEventsList();
            _navigationManager.NavigateTo("events");
        }

    }
}