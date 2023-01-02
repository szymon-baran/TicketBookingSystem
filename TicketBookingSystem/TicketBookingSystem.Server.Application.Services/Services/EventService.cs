using System.Xml.Linq;
using TicketBookingSystem.Server.Application.Abstraction;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IApplicationUserRepository _userRepository;

        public EventService(IEventRepository eventRepository, IApplicationUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Event>> GetEventsAsync(int musicGenre) => await _eventRepository.GetEventsAsync(musicGenre);

        public async Task<List<Event>> GetUpcomingEventsByArtistAsync(int artistId)
        {
            List<Event> events = await _eventRepository.GetEventsAsync(null);

            events = events.Where(x => x.ArtistId == artistId && x.EventTime >= DateTime.Now).ToList();

            return events;
        }

        public async Task<Event> AddEvent(EventAddEditVM model)
        {
            Event @event = new()
            {
                Name = model.Name,
                Description = model.Description,
                EventTime = model.EventTime,
                PhotoUrl = model.PhotoUrl,
                ArtistId = model.ArtistId,
                PlaceId = model.PlaceId,
                AvailableStandingTickets = model.AvailableStandingTickets,
                AvailableSittingTickets = model.AvailableSittingTickets,
                SittingTicketPrice = model.SittingTicketPrice,
                StandingTicketPrice = model.StandingTicketPrice,
                ReducedDiscount = model.ReducedDiscount
            };
            _eventRepository.Add(@event);
            await _eventRepository.SaveAsync();
            return @event;
        }

        public async Task<EventAddEditVM> GetEventDetailsVM(int id)
        {
            Event @event = await _eventRepository.GetByIdAsync(id);
            return new EventAddEditVM()
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                EventTime = @event.EventTime,
                PhotoUrl = @event.PhotoUrl,
                ArtistId = @event.ArtistId,
                PlaceId = @event.PlaceId
            };
        }

        public async Task<TicketPurchaseEventDetailsVM> GetEventDetailsVMForTicketPurchase(int id)
        {
            Event @event = await _eventRepository.GetEventDetailsForTicketPurchase(id);
            return new TicketPurchaseEventDetailsVM()
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                EventTime = @event.EventTime,
                PhotoUrl = @event.PhotoUrl,
                ArtistNickName = @event.Artist.NickName,
                PlaceName = @event.Place.Name,
                PlaceCity = @event.Place.City,
                PlaceCountry = @event.Place.Country,
                AvailableSittingTickets = @event.AvailableSittingTickets,
                AvailableStandingTickets = @event.AvailableStandingTickets,
                MaxSittingTicketsForPlace = @event.Place.MaxSittingCapacity,
                MaxStandingTicketsForPlace = @event.Place.MaxStandingCapacity,
                SittingTicketPrice = @event.SittingTicketPrice,
                StandingTicketPrice = @event.StandingTicketPrice,
                ReducedDiscount = @event.ReducedDiscount,
            };
        }

        public async Task<Event> EditEvent(EventAddEditVM model)
        {
            Event @event = await _eventRepository.GetByIdAsync(model.Id.HasValue ? model.Id.Value : throw new Exception("Missing id value"));
            @event.Name = model.Name;
            @event.Description = model.Description;
            @event.EventTime = model.EventTime;
            @event.PhotoUrl = model.PhotoUrl;
            @event.ArtistId = model.ArtistId;
            @event.PlaceId = model.PlaceId;
            @event.AvailableStandingTickets = model.AvailableStandingTickets;
            @event.AvailableSittingTickets = model.AvailableSittingTickets;
            @event.SittingTicketPrice = model.SittingTicketPrice;
            @event.StandingTicketPrice = model.StandingTicketPrice;
            @event.ReducedDiscount = model.ReducedDiscount;

            _eventRepository.Edit(@event);
            await _eventRepository.SaveAsync();
            return @event;
        }

        public async Task<int> DeleteEvent(int id)
        {
            Event @event = await _eventRepository.GetByIdAsync(id);
            _eventRepository.Remove(@event);
            await _eventRepository.SaveAsync();
            return id;
        }

        public async Task<List<Event>> GetEventsForUserRecommendation(string userId)
        {
            ApplicationUser user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId);
            List<Event> events = await _eventRepository.GetEventsInNextMonthByPrimaryMusicGenre(user.FavouriteMusicGenre);

            // If not enough events by primary genre, fill with secondary ones
            if (events.Count < 4)
            {
                events.AddRange(await _eventRepository.GetEventsInNextMonthBySecondaryMusicGenre(user.FavouriteMusicGenre));
            }
            events = events.OrderBy(x => x.EventTime).Take(4).ToList();

            // Value not nullable then check for 0
            if (user.Age != 0)
            {
                IEnumerable<Event> eventsByAge = await _eventRepository.GetEventsInNextMonthByUserAge(user.Age);
                events.AddRange(eventsByAge.Take(2));
            }

            // If still not enough events, fill with random upcoming ones
            if (events.Count < 4)
            {
                IEnumerable<Event> upcomingEvents = await _eventRepository.GetEventsAsync(null);
                events.AddRange(upcomingEvents.OrderBy(x => x.EventTime).Take(4 - events.Count));
            }

            return events;
        }
    }
}
