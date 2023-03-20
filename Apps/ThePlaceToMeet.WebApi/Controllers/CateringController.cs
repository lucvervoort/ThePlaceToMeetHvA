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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Catering))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Catering>> GetBy(int id)
        {
            var catering = _cateringRepository.GetBy(id);
            if (catering == null)
                return NotFound();
            return Ok(new Catering());
        }
    }
}