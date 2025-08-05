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
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
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
           return RedirectToAction("Index", "PortfolioDashboard", new { portfolioId = transaction.PortfolioId });
        }
    }
}
