using Microsoft.AspNetCore.Mvc;
using TrackWise.Services.Interfaces;

namespace TrackWise.Web.Controllers
{
    [Route("api/assets")]
    public class AssetsController : Controller
    {
        private readonly IAssetService assetService;

        public AssetsController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        [HttpGet("search")]
        public IActionResult SearchAssets(string query,string? type)
        {
            var results = assetService.GetAssetsByQuery(query,type)
                .Select(a => new { id = a.Id, text = $"{a.Name} ({a.Symbol}) - {a.ExchangeName}" })
                .ToList();

            return Ok(results);
        }
    }
}
