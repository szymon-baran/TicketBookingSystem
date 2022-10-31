using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
    }
}