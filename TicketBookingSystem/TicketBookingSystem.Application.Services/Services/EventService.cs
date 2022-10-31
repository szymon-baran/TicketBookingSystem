using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Data.Abstraction;
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
    }
}
