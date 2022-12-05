using System.Threading.Tasks;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface ITicketService
    {
        List<ReservedTicketVM> Tickets { get; set; }
        Task GetTicketsList();
        Task BuyTicket(BuyOperationVM model);
    }
}