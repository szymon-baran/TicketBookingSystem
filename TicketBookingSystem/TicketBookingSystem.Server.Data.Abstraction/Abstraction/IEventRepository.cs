using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Abstraction
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetEventsAsync(int? musicGenreParam);
        Task<List<Event>> GetEventsInNextYearByPrimaryMusicGenre(MusicGenre musicGenre);
        Task<List<Event>> GetEventsInNextYearBySecondaryMusicGenre(MusicGenre musicGenre);
        Task<List<Event>> GetEventsInNextYearByUserAge(int userAge);
        Task<Event> GetEventDetailsForTicketPurchase(int id);
        Task SynchronizeTicketsNums(int eventId, int boughtSitting, int boughtStanding);
    }
}
