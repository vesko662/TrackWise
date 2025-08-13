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
        public PortfolioDashboardController(IPortfolioDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        public IActionResult Index(string Id)
        {
            ViewBag.Id =Id;
            PortfolioDashboardViewModel model = new PortfolioDashboardViewModel();
            model.ChartData = dashboardService.BuildChartData(Id);
            model.HoldingData=dashboardService.BuildHoldingData(Id);
            model.AssetClassesData=dashboardService.BuildAssetClassesData(Id);
            model.TransactionData=dashboardService.BuildTransactionData(Id);
            return View(model);
        }
    }
}
