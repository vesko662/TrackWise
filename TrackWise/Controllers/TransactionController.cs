using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackWise.Models.Dto.TransactionDtos;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService transactionService;
        public readonly IPortfolioDashboardService portfolioDashboardService;
        private readonly ICurrencyService currencyService;
        public TransactionController(ITransactionService transactionService, IPortfolioDashboardService portfolioDashboardService,ICurrencyService currencyService)
        {
            this.transactionService = transactionService;
            this.portfolioDashboardService = portfolioDashboardService;
            this.currencyService = currencyService;
        }
        public IActionResult Index(string portfolioId)
        {
            return View(new TransactionCreateDto() { PortfolioId = portfolioId });
        }

        [HttpPost]
        public IActionResult Create(TransactionCreateDto transaction)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", transaction);
            }
            transactionService.AddTransaction(transaction);
            return RedirectToAction("Index", "PortfolioDashboard", new { Id = transaction.PortfolioId });
        }

        [HttpPost]
        public IActionResult Delete(string transactionId, string portfolioId)
        {
            transactionService.DeleteTransaction(portfolioId, transactionId);

            return RedirectToAction("Index", "PortfolioDashboard", new { Id = portfolioId });
        }


        public IActionResult All(string portfolioId)
        {
            ViewBag.Id = portfolioId;
            ViewBag.Symbol = currencyService.GetCurrencySymbol(currencyService.GetCurrency(portfolioId).Code);
            return View(portfolioDashboardService.BuildTransactionData(portfolioId));
        }
    }
}
