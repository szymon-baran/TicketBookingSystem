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
    }
}
