using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Application.Abstraction
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync(int musicGenre);
        Task<List<Event>> GetUpcomingEventsByArtistAsync(int artistId);
        Task<Event> AddEvent(EventAddEditVM model);
        Task<EventAddEditVM> GetEventDetailsVM(int id);
        Task<TicketPurchaseEventDetailsVM> GetEventDetailsVMForTicketPurchase(int id);
        Task<Event> EditEvent(EventAddEditVM model);
        Task<int> DeleteEvent(int id);
        Task<List<RecommendedEventVM>> GetEventsForUserRecommendation(string userId);
    }
}