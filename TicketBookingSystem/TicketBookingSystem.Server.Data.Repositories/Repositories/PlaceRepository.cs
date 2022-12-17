using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
