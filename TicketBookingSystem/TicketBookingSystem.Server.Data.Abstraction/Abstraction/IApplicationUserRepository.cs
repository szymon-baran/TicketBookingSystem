using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Abstraction
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserDetailsById(string id);
    }
}
