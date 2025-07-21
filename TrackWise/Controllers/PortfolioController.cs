using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        private readonly ICurrencyService currencyService;

        public PortfolioController(IPortfolioService portfolioService, ICurrencyService currencyService)
        {
            this.portfolioService = portfolioService;
            this.currencyService = currencyService;
        }

        private void LoadCurrencies()
        {
            ViewBag.Currencies = new SelectList(currencyService.GetAll(), "Id", "Code");
        }
        public IActionResult Index()
        {
            var viewModel = new PortfolioIndexViewModel
            {
                Portfolios = portfolioService.GetPortfolios(),
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

            portfolioService.AddPortfolio(model.CreateDto);
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

            portfolioService.AddPortfolio(model.CreateDto);
            return RedirectToAction("Index");
        }


        public IActionResult Settings(Guid id)
        {
            LoadCurrencies();
            return View(portfolioService.GetPortfolioForEdit(id));
        }
        [HttpPost]
        public IActionResult Settings(PortfolioUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                LoadCurrencies();
                return View(portfolioService.GetPortfolioForEdit(model.Id));
            }
            portfolioService.UpdatePortfolio(model);

            return RedirectToAction("Index");
        }

      [HttpPost]
        public IActionResult Delete(Guid id)
        {
            portfolioService.DeletePortfolio(id);
            return RedirectToAction("Index");
        }
    }
}
