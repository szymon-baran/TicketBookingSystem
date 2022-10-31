using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IEventService
    {
        List<Event> Events { get; set; }
        Task GetEventsList();
    }
}