using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Abstraction
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketsAsync(string userId);
    }
}
