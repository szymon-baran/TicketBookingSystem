using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetUserDetailsById(string id)
        {
            return await _context.ApplicationUsers.Include(x => x.Tickets).ThenInclude(x => x.Event).ThenInclude(x => x.Artist).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
