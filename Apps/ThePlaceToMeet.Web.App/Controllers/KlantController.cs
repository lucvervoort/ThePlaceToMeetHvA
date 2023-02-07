using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThePlaceToMeet.Filters;
using ThePlaceToMeet.Domain;

namespace ThePlaceToMeet.Controllers
{
    public class KlantController : Controller
    {
        [ServiceFilter(typeof(KlantFilter))]
        [Authorize]
        public IActionResult Index(Customer klant)
        {
            if (klant == null)
                return View();
            return View(klant.Reservaties);
        }
    }
}
