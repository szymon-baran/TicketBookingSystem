using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetEventsAsync(int? musicGenreParam)
        {
            List<Event> events = await _context.Events.Where(x => x.EventTime > DateTime.Now.AddHours(-24))
                                        .Include(x => x.Artist)
                                        .Include(x => x.Place)
                                        .ToListAsync();

            if (musicGenreParam != null)
            {
                MusicGenre musicGenre = (MusicGenre)musicGenreParam;
                events = events.Where(x => musicGenre == MusicGenre.None || x.Artist.PrimaryMusicGenre == musicGenre || x.Artist.SecondaryMusicGenre == musicGenre).ToList();
            }

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
