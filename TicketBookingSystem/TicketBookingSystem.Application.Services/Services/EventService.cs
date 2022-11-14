using System.Xml.Linq;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetEventsAsync() => await _eventRepository.GetEventsAsync();

        public async Task<Event> AddEvent(EventAddEditVM model)
        {
            Event @event = new()
            {
                Name = model.Name,
                Description = model.Description,
                EventTime = model.EventTime,
                PhotoUrl = model.PhotoUrl,
                ArtistId = model.ArtistId,
                PlaceId = 1
            };
            _eventRepository.Add(@event);
            await _eventRepository.SaveAsync();
            return @event;
        }

        public async Task<EventAddEditVM> GetEventDetailsVM(int id)
        {
            Event @event = await _eventRepository.GetByIdAsync(id);
            return new EventAddEditVM()
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                EventTime = @event.EventTime,
                PhotoUrl = @event.PhotoUrl,
                ArtistId = @event.ArtistId,
                PlaceId = @event.PlaceId
            };
        }

        public async Task<Event> EditEvent(EventAddEditVM model)
        {
            Event @event = await _eventRepository.GetByIdAsync(model.Id.HasValue ? model.Id.Value : throw new Exception("Missing id value"));
            @event.Name = model.Name;
            @event.Description = model.Description;
            @event.EventTime = model.EventTime;
            @event.PhotoUrl = model.PhotoUrl;
            @event.ArtistId = model.ArtistId;
            @event.PlaceId = model.PlaceId;
            _eventRepository.Edit(@event);
            await _eventRepository.SaveAsync();
            return @event;
        }

        public async Task<int> DeleteEvent(int id)
        {
            Event @event = await _eventRepository.GetByIdAsync(id);
            _eventRepository.Remove(@event);
            await _eventRepository.SaveAsync();
            return id;
        }
    }
}
