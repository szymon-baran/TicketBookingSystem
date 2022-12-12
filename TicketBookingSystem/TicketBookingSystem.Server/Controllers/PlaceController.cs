using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Controllers
{
    public class PlaceController : AppController
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("getPlacesToSelectList")]
        public async Task<ActionResult<List<TicketPurchasePlaceDetailsVM>>> GetPlacesToSelectList()
        {
            return Ok(await _placeService.GetPlacesToSelectList());
        }
    }
}
