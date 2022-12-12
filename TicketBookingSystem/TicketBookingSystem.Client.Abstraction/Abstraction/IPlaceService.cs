using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface IPlaceService
    {
        List<TicketPurchasePlaceDetailsVM>? PlacesToSelectList { get; set; }
        Task GetPlacesToSelectList();
    }
}