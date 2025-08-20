
namespace TrackWise.Services.Interfaces
{
    public interface IPriceService
    {
        bool CheckDate(string assetId, DateTime date);

        void AddTodayPrice(string assetId, decimal price);

        void AddPriceHistory(string assetId);

        void UpdatePricesForPortfolio(string portfolioId);

        decimal GetLatestPrice(string assetId);
    }
}
