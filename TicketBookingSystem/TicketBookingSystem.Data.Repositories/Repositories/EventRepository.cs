using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            List<Event> events = await _context.Events.Include(x => x.Artist)
                                        .Include(x => x.Place)
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
