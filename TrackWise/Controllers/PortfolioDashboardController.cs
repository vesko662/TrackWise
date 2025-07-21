using Microsoft.AspNetCore.Mvc;

namespace TrackWise.Web.Controllers
{
    public class PortfolioDashboardController : Controller
    {
        public IActionResult Index(Guid Id)
        {
            ViewBag.Id =Id;
            return View();
        }
    }
}
