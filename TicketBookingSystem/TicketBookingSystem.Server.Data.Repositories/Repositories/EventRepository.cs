using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetEventsAsync(int? musicGenreParam)
        {
            MusicGenre musicGenre = musicGenreParam.HasValue ? (MusicGenre)musicGenreParam : MusicGenre.None;
            List<Event> events = await _context.Events.Where(x => x.EventTime > DateTime.Now.AddHours(-24) &&
                                        (musicGenre == MusicGenre.None ||
                                        x.Artist.PrimaryMusicGenre == musicGenre ||
                                        x.Artist.SecondaryMusicGenre == musicGenre))
                                        .Include(x => x.Artist)
                                        .Include(x => x.Place)
                                        .OrderBy(x => x.EventTime)
                                        .ToListAsync();

            return events;
        }

        public async Task<List<Event>> GetEventsInNextYearByPrimaryMusicGenre(MusicGenre musicGenre)
        {
            List<Event> events = await _context.Events.Include(x => x.Artist)
                                                .Include(x => x.Place)
                                                .Where(x => x.EventTime > DateTime.Now
                                                            && x.EventTime < DateTime.Now.AddYears(1)
                                                            && x.Artist.PrimaryMusicGenre == musicGenre)
                                                .OrderBy(x => x.EventTime)
                                                .ToListAsync();

            return events;
        }

        public async Task<List<Event>> GetEventsInNextYearBySecondaryMusicGenre(MusicGenre musicGenre)
        {
            List<Event> events = await _context.Events.Include(x => x.Artist)
                                                .Include(x => x.Place)
                                                .Where(x => x.EventTime > DateTime.Now
                                                            && x.EventTime < DateTime.Now.AddYears(1)
                                                            && x.Artist.SecondaryMusicGenre == musicGenre)
                                                .OrderBy(x => x.EventTime)
                                                .ToListAsync();

            return events;
        }

        public async Task<List<Event>> GetEventsInNextYearByUserAge(int userAge)
        {
            List<Event> events = await _context.Events.Include(x => x.Artist)
                                                .Include(x => x.Place)
                                                .Where(x => x.EventTime > DateTime.Now
                                                            && x.EventTime < DateTime.Now.AddYears(1)
                                                            && x.Artist.AverageFanbaseAge > ((int)Math.Floor(0.8 * userAge))
                                                            && x.Artist.AverageFanbaseAge < ((int)Math.Floor(1.2 * userAge)))
                                                .OrderBy(x => x.EventTime)
                                                .ToListAsync();

            return events;
        }

        public async Task<Event> GetEventDetailsForTicketPurchase(int id)
        {
            Event @event = await _context.Events.Where(x => x.Id == id)
                                        .Include(x => x.Artist)
                                        .Include(x => x.Place)
                                        .FirstOrDefaultAsync();
            return @event;
        }

        public async Task SynchronizeTicketsNums(int eventId, int boughtSitting, int boughtStanding)
        {
            Event @event = _context.Events.FirstOrDefault(x => x.Id == eventId) ?? throw new Exception("No data");
            @event.AvailableSittingTickets -= boughtSitting;
            @event.AvailableStandingTickets -= boughtStanding;
            _context.Update(@event);
            await _context.SaveChangesAsync();
        }
    }
}
