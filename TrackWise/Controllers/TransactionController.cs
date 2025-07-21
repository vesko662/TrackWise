using Microsoft.AspNetCore.Mvc;

namespace TrackWise.Web.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
