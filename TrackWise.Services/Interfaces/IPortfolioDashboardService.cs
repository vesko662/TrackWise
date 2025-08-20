using TrackWise.Models.Dto.PortfolioDashboard;

namespace TrackWise.Services.Interfaces
{
    public interface IPortfolioDashboardService
    {
        public PortfolioDashboardChartData BuildChartData(string portfolioId);
        public IEnumerable<PortfolioDashboardHoldingData> BuildHoldingData(string portfolioId); 

        public IEnumerable<PortfolioDashboardTransactionData> BuildTransactionData(string portfolioId);
        public PortfolioDashboardAssetClassesData BuildAssetClassesData(string portfolioId);
    }
}
