using Microsoft.AspNetCore.Mvc;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
