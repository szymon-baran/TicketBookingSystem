using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IEventService
    {
        List<Event> Events { get; set; }
        EventAddEditVM Event { get; set; }
        Task GetEventsList();
        Task AddEvent(EventAddEditVM model);
        Task<EventAddEditVM> GetEventDetails(int id);
        Task EditEvent(EventAddEditVM model);
        Task DeleteEvent(int id);
    }
}