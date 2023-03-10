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
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(ILogger<DiscountController> logger, IDiscountRepository discountRepository)
        {
            _logger = logger;
            _discountRepository = discountRepository;
        }

        [HttpGet(Name = "DiscountController::Discounts")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Discount>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Discount>>> Discounts()
        {
            _logger?.LogDebug("-> DiscountController::Discounts");
            // TODO LVET: var vergaderuimte = await _vergaderruimteRepository.GetAsync();
            var discounts = _discountRepository.GetAll();
            if (discounts == null)
            {
                _logger?.LogDebug("<- DiscountController::Discounts (FAIL)");
                return NotFound(new List<MeetingRoom>());
            }
            _logger?.LogDebug("<- DiscountController::Discounts (OK)");
            return Ok(discounts);
        }

        [HttpGet("{id:int}", Name = "DiscountController::GetById")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Discount))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Discount>> GetById(int id)
        {
            _logger?.LogDebug("-> DiscountController::GetById");
            var discount = _discountRepository.GetById(id);
            if (discount == null)
            {
                _logger?.LogDebug("<- DiscountController::GetById (Not found)");
                return NotFound();
            }
            _logger?.LogDebug("<- DiscountController::GetById");
            return Ok(discount);
        }
    }
}