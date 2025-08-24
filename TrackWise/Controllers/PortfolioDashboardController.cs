using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackWise.Models.Dto.PortfolioDashboard;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    [Authorize]
    public class PortfolioDashboardController : Controller
    {
        private readonly IPortfolioDashboardService dashboardService;
        private readonly ICurrencyService currencyService;
        public PortfolioDashboardController(IPortfolioDashboardService dashboardService, ICurrencyService currencyService)
        {
            this.dashboardService = dashboardService;
            this.currencyService = currencyService;
        }
        public IActionResult Index(string Id)
        {
            ViewBag.Id =Id;
            PortfolioDashboardViewModel model = new PortfolioDashboardViewModel();
            model.ChartData = dashboardService.BuildChartData(Id);
            model.HoldingData=dashboardService.BuildHoldingData(Id);
            model.AssetClassesData=dashboardService.BuildAssetClassesData(Id);
            model.TransactionData=dashboardService.BuildTransactionData(Id).Take(3);

            var currency=currencyService.GetCurrency(Id);
            ViewBag.Symbol= currencyService.GetCurrencySymbol(currency.Code);
            ViewBag.CurrencyCode = currency.Code;
            return View(model);
        }
    }
}
