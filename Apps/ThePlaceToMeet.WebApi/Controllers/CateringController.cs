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
    public class CateringController : ControllerBase
    {
        private readonly ILogger<CateringController> _logger;
        private readonly ICateringRepository _cateringRepository;

        public CateringController(ILogger<CateringController> logger, ICateringRepository cateringRepository)
        {
            _logger = logger;
            _cateringRepository = cateringRepository;
        }

        [HttpGet(Name = "Catering::Caterings")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Catering>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Catering>>> Caterings()
        {
            _logger?.LogDebug("-> CateringController::Caterings");
            // TODO LVET: var vergaderuimte = await _vergaderruimteRepository.GetAsync();
            var cateringItems = _cateringRepository.GetAll();
            if (cateringItems == null)
            {
                _logger?.LogDebug("<- CateringController::Caterings (FAIL)");
                return NotFound(new List<Catering>());
            }
            _logger?.LogDebug("<- CateringController::Caterings (OK)");
            return Ok(cateringItems);
        }

        [HttpGet("{id:int}", Name = "Catering::GetBy")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Catering))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Catering>> GetBy(int id)
        {
            _logger?.LogDebug("-> CateringController::GetBy");
            var catering = _cateringRepository.GetBy(id);
            if (catering == null)
            {
                _logger?.LogDebug("<- CateringController::GetBy (not found)");
                return NotFound();
            }
            _logger?.LogDebug("<- CateringController::GetBy");
            return Ok(new Catering());
        }

        [HttpPost(Name = "Catering::Add")]
        // No anonymous to prevent flooding of db
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(Catering catering)
        {
            _logger?.LogDebug("-> CateringController::Add");
            try
            {
                _cateringRepository.Add(catering);
                _cateringRepository.SaveChanges();
                _logger?.LogDebug("<- CateringController::Add");
                return Ok();
            }
            catch (Exception e)
            {
                _logger?.LogError($"<- CateringController::Add ({e.Message})");
            }
            _logger?.LogDebug("<- CateringController::Add (bad request)");
            return BadRequest();
        }
    }
}