using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketBookingSystem.Server.Application.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvents(int id) => Ok(await _eventService.GetEventsAsync(id));

        [HttpGet("getEventsForUserRecommendation")]
        public async Task<IActionResult> GetEventsForUserRecommendation()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _eventService.GetEventsForUserRecommendation(userId));
        }

        [HttpGet("getUpcomingEventsByArtist")]
        public async Task<IActionResult> GetUpcomingEventsByArtist(int artistId) => Ok(await _eventService.GetUpcomingEventsByArtistAsync(artistId));

        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(EventAddEditVM model) => Ok(await _eventService.AddEvent(model));

        [HttpGet("details/{id}")]
        public async Task<ActionResult<EventAddEditVM>> GetEventDetails(int id) => Ok(await _eventService.GetEventDetailsVM(id));

        [HttpGet("purchaseDetails/{id}")]
        public async Task<ActionResult<TicketPurchaseEventDetailsVM>> GetEventDetailsForTicketPurchase(int id) => Ok(await _eventService.GetEventDetailsVMForTicketPurchase(id));

        [HttpPut]
        public async Task<ActionResult<Event>> EditEvent(EventAddEditVM model) => Ok(await _eventService.EditEvent(model));

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEvent(int id) => Ok(await _eventService.DeleteEvent(id));
    }
}
