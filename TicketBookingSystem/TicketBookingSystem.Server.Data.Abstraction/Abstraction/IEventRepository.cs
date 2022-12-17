using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Abstraction
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetEventsAsync(int? musicGenreParam);
        Task<Event> GetEventDetailsForTicketPurchase(int id);
        Task SynchronizeTicketsNums(int eventId, int boughtSitting, int boughtStanding);
    }
}
