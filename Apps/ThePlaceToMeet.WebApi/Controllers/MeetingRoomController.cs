using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

        [HttpGet(Name = "MeetingRoomController::MeetingRooms")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MeetingRoom>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> MeetingRooms()
        {
            _logger?.LogDebug("-> MeetingRoomController::MeetingRooms");
            // TODO LVET: var vergaderuimte = await _reservationRepository.GetAsync();
            var meetingRooms = _meetingRoomRepository.GetAll();
            if (meetingRooms == null)
            {
                _logger?.LogDebug("<- MeetingRoomController::MeetingRooms (FAIL)");
                return NotFound(new List<MeetingRoom>());
            }
            _logger?.LogDebug("<- MeetingRoomController::MeetingRooms (OK)");
            return Ok(meetingRooms);
        }

        [HttpGet("max/{maxAantalPersonen:int}", Name = "MeetingRoomController::GetByMaxNumberOfPersons")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MeetingRoom>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetByMaxNumberOfPersons(int maxNumberOfPersons)
        {
            _logger?.LogDebug("-> MeetingRoomController::GetByMaxNumberOfPersons");
            var meetingrooms = _meetingRoomRepository.GetByMaxAantalPersonen(maxNumberOfPersons);
            if (meetingrooms == null || meetingrooms.Count() == 0)
            {
                _logger?.LogDebug("<- MeetingRoomController::GetByMaxNumberOfPersons (Not found)");
                return NotFound(new List<MeetingRoom>());
            }
            _logger?.LogDebug("<- MeetingRoomController::GetByMaxNumberOfPersons");
            return Ok(meetingrooms);
        }

        [HttpGet("{id:int}", Name = "MeetingRoomController::GetById")]
        [AllowAnonymous]        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeetingRoom))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MeetingRoom>> GetById(int id)
        {
            _logger?.LogDebug("-> MeetingRoomController::GetById");
            var meetingRoom = _meetingRoomRepository.GetById(id);
            if (meetingRoom == null)
            {
                _logger?.LogDebug("<- MeetingRoomController::GetById (Not found)");
                return NotFound();
            }
            _logger?.LogDebug("<- MeetingRoomController::GetById");
            return Ok(meetingRoom);
        }
    }
}