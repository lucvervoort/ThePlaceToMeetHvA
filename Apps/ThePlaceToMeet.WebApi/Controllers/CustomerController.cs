using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ThePlaceToMeet.Contracts.Interfaces;
using ThePlaceToMeet.Contracts.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ThePlaceToMeet.WebApi.Controllers
{
    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    [Authorize]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository klantRepository)
        {
            _logger = logger;
            _customerRepository = klantRepository;
        }

        // TODO: ?limit=20        
        [HttpGet(Name = "Customer::Customers")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Customer>>> Customers()
        {
            _logger?.LogDebug("-> CustomerController::Customers");
            // TODO LVET: var vergaderuimte = await _vergaderruimteRepository.GetAsync();
            var klanten = _customerRepository.GetAll();
            if (klanten == null)
            {
                _logger?.LogDebug("<- CustomerController::Customers (Not found)");
                return NotFound(new List<Customer>());
            }
            _logger?.LogDebug("<- CustomerController::Customers (OK)");
            return Ok(klanten);
        }

        [HttpGet("{email}", Name = "Customer::GetByEmail")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetByEmail(string email)
        {
            _logger?.LogDebug("-> CustomerController::GetByEmail");
            var catering = _customerRepository.GetByEmail(email);
            if (catering == null)
            {
                _logger?.LogDebug("<- CustomerController::GetByEmail (Not found)");
                return NotFound();
            }
            _logger?.LogDebug("<- CustomerController::GetByEmail");
            return Ok(new Customer());
        }

        [HttpPost(Name = "Customer::Add")]
        // No anonymous to prevent flooding of db
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(Customer klant)
        {
            _logger?.LogDebug("-> CustomerController::Add");
            try
            {
                _customerRepository.Add(klant);
                _customerRepository.SaveChanges();
                _logger?.LogDebug("<- CustomerController::Add");
                return Ok();
            }
            catch(Exception e)
            {
                _logger?.LogError($"<- KlantController::Add ({e.Message})");
            }
            _logger?.LogDebug("<- CustomerController::GetByEmail (Bad request)");
            return BadRequest();
        }
    }
}