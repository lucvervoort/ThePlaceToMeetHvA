using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.WebApi.Controllers
{

    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    [Route("[controller]")]
    public class MeetingRoomController : ControllerBase
    {
        private readonly ILogger<MeetingRoomController> _logger;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        public MeetingRoomController(ILogger<MeetingRoomController> logger, IMeetingRoomRepository meetingRoomRepository)
        {
            _logger = logger;
            _meetingRoomRepository = meetingRoomRepository;
        }

        [HttpGet(Name = "MeetingRoom::MeetingRooms")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MeetingRoom>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> MeetingRooms()
        {
            _logger?.LogDebug("-> Vergaderruimte::MeetingRooms");
            // TODO LVET: var vergaderuimte = await _vergaderruimteRepository.GetAsync();
            var vergaderruimtes = _meetingRoomRepository.GetAll();
            if (vergaderruimtes == null)
            {
                _logger?.LogDebug("<- Vergaderruimte::MeetingRooms (FAIL)");
                return NotFound(new List<MeetingRoom>());
            }
            _logger?.LogDebug("<- Vergaderruimte::MeetingRooms (OK)");
            return Ok(vergaderruimtes);
        }

        [HttpGet("max/{maxAantalPersonen:int}", Name = "MeetingRoom::GetByMaxAantalPersonen")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MeetingRoom>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetByMaxNumberOfPersons(int maaxNumberOfPersons)
        {
            var meetingrooms = _meetingRoomRepository.GetByMaxAantalPersonen(maaxNumberOfPersons);
            if (meetingrooms == null || meetingrooms.Count() == 0)
                return NotFound(new List<MeetingRoom>());
            return Ok(meetingrooms);
        }

        [HttpGet("{id:int}", Name = "MeetingRoom::GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeetingRoom))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MeetingRoom>> GetById(int id)
        {
            var vergaderruimte = _meetingRoomRepository.GetById(id);
            if (vergaderruimte == null)
                return NotFound();
            return Ok(new MeetingRoom());
        }
    }
}