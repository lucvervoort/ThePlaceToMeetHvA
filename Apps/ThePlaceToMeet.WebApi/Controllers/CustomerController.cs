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
    [Route("[controller]")]
    //[Authorize] // for IdentityServer
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Customer>>> Customers()
        {
            _logger?.LogDebug("-> CateringController::Customers");
            // TODO LVET: var vergaderuimte = await _vergaderruimteRepository.GetAsync();
            var klanten = _customerRepository.GetAll();
            if (klanten == null)
            {
                _logger?.LogDebug("<- KlantController::Customers (FAIL)");
                return NotFound(new List<Customer>());
            }
            _logger?.LogDebug("<- KlantController::Customers (OK)");
            return Ok(klanten);
        }

        [HttpGet("{email}", Name = "Customer::GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetByEmail(string email)
        {
            var catering = _customerRepository.GetByEmail(email);
            if (catering == null)
                return NotFound();
            return Ok(new Customer());
        }

        [HttpPost(Name = "Customer::Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(Customer klant)
        {
            try
            {
                _customerRepository.Add(klant);
                _customerRepository.SaveChanges();
                return Ok();
            }
            catch(Exception e)
            {
                _logger?.LogError($"<- KlantController::Add ({e.Message})");
            }
            return BadRequest();
        }
    }
}