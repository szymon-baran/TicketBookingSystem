using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Application.Abstraction
{
    public interface IPlaceService
    {
        Task<List<TicketPurchasePlaceDetailsVM>> GetPlacesToSelectList();
    }
}