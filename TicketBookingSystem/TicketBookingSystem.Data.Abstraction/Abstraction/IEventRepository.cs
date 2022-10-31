using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Abstraction
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetEventsAsync();
    }
}
