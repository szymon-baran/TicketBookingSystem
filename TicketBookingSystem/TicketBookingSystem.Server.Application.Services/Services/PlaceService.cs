using TicketBookingSystem.Server.Application.Abstraction;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<List<TicketPurchasePlaceDetailsVM>> GetPlacesToSelectList()
        {
            IEnumerable<Place> places = await _placeRepository.GetAllAsync();
            return places.Select(x => new TicketPurchasePlaceDetailsVM()
            {
                Id = x.Id,
                Name = $"{x.Name} - {x.City} ({x.Country})",
                MaxSittingCapacity = x.MaxSittingCapacity,
                MaxStandingCapacity = x.MaxStandingCapacity
            }).ToList();
        }
    }
}
