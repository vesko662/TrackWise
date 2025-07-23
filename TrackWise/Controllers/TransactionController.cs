using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackWise.Models.Dto.TransactionDtos;

namespace TrackWise.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        public IActionResult Index(string portfolioId)
        {
            return View(new TransactionCreateDto() { PortfolioId = portfolioId });
        }


    }
}
