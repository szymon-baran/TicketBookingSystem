using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IPlaceService
    {
        Task<List<TicketPurchasePlaceDetailsVM>> GetPlacesToSelectList();
    }
}