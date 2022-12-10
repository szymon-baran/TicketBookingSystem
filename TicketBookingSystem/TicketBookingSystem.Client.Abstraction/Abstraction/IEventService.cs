using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IEventService
    {
        List<Event> Events { get; set; }
        EventAddEditVM Event { get; set; }
        Task GetEventsList(MusicGenre id = MusicGenre.None);
        Task GetUpcomingEventsListByArtist(int artistId);
        Task AddEvent(EventAddEditVM model);
        Task<EventAddEditVM> GetEventDetails(int id);
        Task<TicketPurchaseEventDetailsVM> GetEventDetailsForTicketPurchase(int id);
        Task EditEvent(EventAddEditVM model);
        Task DeleteEvent(int id);
    }
}