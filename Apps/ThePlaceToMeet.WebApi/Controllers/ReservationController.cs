using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ThePlaceToMeet.Contracts.Interfaces;
using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.WebApi.Controllers
{

    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    [Authorize]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(ILogger<ReservationController> logger, IReservationRepository meetingRoomRepository)
        {
            _logger = logger;
            _reservationRepository = meetingRoomRepository;
        }

        [HttpGet(Name = "ReservationController::Reservations")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Reservation>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Reservation>>> Reservations()
        {
            _logger?.LogDebug("-> ReservationController::Reservations");
            // TODO LVET: var vergaderuimte = await _reservationRepository.GetAsync();
            var reservations = _reservationRepository.GetAll();
            if (reservations == null)
            {
                _logger?.LogDebug("<- ReservationController::Reservations (FAIL)");
                return NotFound(new List<Reservation>());
            }
            _logger?.LogDebug("<- ReservationController::Reservations (OK)");
            return Ok(reservations);
        }

        [HttpGet("{id:int}", Name = "ReservationController::GetById")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeetingRoom))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reservation>> GetById(int id)
        {
            _logger?.LogDebug("-> ReservationController::GetById");
            var meetingRoom = _reservationRepository.GetById(id);
            if (meetingRoom == null)
            {
                _logger?.LogDebug("<- ReservationController::GetById (Not found)");
                return NotFound();
            }
            _logger?.LogDebug("<- ReservationController::GetById");
            return Ok(meetingRoom);
        }
    }
}