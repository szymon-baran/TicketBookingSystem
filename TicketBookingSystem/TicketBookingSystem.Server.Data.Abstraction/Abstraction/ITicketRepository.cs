using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Data.Abstraction
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketsAsync(string userId);
    }
}
