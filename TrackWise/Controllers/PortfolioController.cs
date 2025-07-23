using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        private readonly ICurrencyService currencyService;
        public PortfolioController(IPortfolioService portfolioService, ICurrencyService currencyService)
        {
            this.portfolioService = portfolioService;
            this.currencyService = currencyService;
        }
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private void LoadCurrencies()
        {
            ViewBag.Currencies = new SelectList(currencyService.GetAll(), "Id", "Code");
        }
        public IActionResult Index()
        {
            var viewModel = new PortfolioIndexViewModel
            {
                Portfolios = portfolioService.GetPortfolios(UserId),
                CreateDto = new PortfolioCreateDto()
            };
            LoadCurrencies();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(PortfolioIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
          
            portfolioService.AddPortfolio(model.CreateDto, UserId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(PortfolioIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCurrencies();
                return View("Index", model);
            }

            portfolioService.AddPortfolio(model.CreateDto, UserId);
            return RedirectToAction("Index");
        }


        public IActionResult Settings(string id)
        {
            LoadCurrencies();
            return View(portfolioService.GetPortfolioForEdit(id, UserId));
        }
        [HttpPost]
        public IActionResult Settings(PortfolioUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                LoadCurrencies();
                return View(portfolioService.GetPortfolioForEdit(model.Id, UserId));
            }
            portfolioService.UpdatePortfolio(model, UserId);

            return RedirectToAction("Index");
        }

      [HttpPost]
        public IActionResult Delete(string id)
        {
            portfolioService.DeletePortfolio(id, UserId);
            return RedirectToAction("Index");
        }
    }
}
