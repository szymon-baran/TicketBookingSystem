using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
        Task<Event> AddEvent(EventAddEditVM model);
        Task<EventAddEditVM> GetEventDetailsVM(int id);
        Task<TicketPurchaseEventDetailsVM> GetEventDetailsVMForTicketPurchase(int id);
        Task<Event> EditEvent(EventAddEditVM model);
        Task<int> DeleteEvent(int id);
    }
}