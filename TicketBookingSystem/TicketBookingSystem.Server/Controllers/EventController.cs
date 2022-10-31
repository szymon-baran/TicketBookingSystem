using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.Abstraction;
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

        [HttpGet]
        public async Task<IActionResult> GetEvents() => Ok(await _eventService.GetEventsAsync());
    }
}
