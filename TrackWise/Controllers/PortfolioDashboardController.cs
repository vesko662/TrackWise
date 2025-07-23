using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackWise.Web.Controllers
{
    [Authorize]
    public class PortfolioDashboardController : Controller
    {
        public IActionResult Index(string Id)
        {
            ViewBag.Id =Id;
            return View();
        }
    }
}
