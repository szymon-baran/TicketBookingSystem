using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("getArtists")]
        public async Task<IActionResult> GetArtists()
        {
            List<Artist> artists = await _artistService.GetArtists();

            return Ok(artists);
        }
    }
}
