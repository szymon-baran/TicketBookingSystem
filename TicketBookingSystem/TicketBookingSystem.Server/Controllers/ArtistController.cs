using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Controllers
{
    public class ArtistController : AppController
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        [HttpGet("getArtistById")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            Artist artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return NotFound("Brak artysty o podanym id");
            }

            return Ok(artist);
        }

        [HttpGet("getArtists")]
        public async Task<IActionResult> GetArtists()
        {
            List<Artist> artists = await _artistService.GetArtists();

            return Ok(artists);
        }

        [HttpPost("addArtist")]
        public async Task<IActionResult> AddArtist(AddArtistVM model)
        {
            Artist artist = _mapper.Map<Artist>(model);

            int addedArtistId = await _artistService.AddArtist(artist);

            return Ok(addedArtistId);
        }

        [HttpPut("editArtist")]
        public async Task<IActionResult> EditArtist(EditArtistVM model)
        {
            Artist artist = _mapper.Map<Artist>(model);

            bool result = await _artistService.EditArtist(artist);
            if (!result)
            {
                return BadRequest("Błąd przy próbie zaktualizowania danych");
            }

            return Ok();
        }

        [HttpDelete("deleteArtist")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            bool result = await _artistService.DeleteArtist(id);
            if (!result)
            {
                return NotFound("Błąd przy próbie usunięcia");
            }

            return Ok();
        }

        [HttpGet("getArtistsToSelectList")]
        public async Task<ActionResult<Dictionary<int, string>>> GetArtistsToSelectList()
        {
            return Ok(await _artistService.GetArtistsToSelectList());
        }
    }
}
