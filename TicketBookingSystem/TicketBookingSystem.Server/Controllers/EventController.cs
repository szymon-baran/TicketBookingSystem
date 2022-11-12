using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.Abstraction;
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

        [HttpGet]
        public async Task<IActionResult> GetEvents() => Ok(await _eventService.GetEventsAsync());

        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(EventAddEditVM model) => Ok(await _eventService.AddEvent(model));

        [HttpGet("{id}")]
        public async Task<ActionResult<EventAddEditVM>> GetEventDetails(int id) => Ok(await _eventService.GetEventDetailsVM(id));

        [HttpPut]
        public async Task<ActionResult<Event>> EditEvent(EventAddEditVM model) => Ok(await _eventService.EditEvent(model));

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEvent(int id) => Ok(await _eventService.DeleteEvent(id));
    }
}
