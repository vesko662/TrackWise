
namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardChartData
    {
        public string PortfolioId { get; set; }

        public decimal TotalValue { get; set; }
        public decimal AnnualReturn { get; set; }
        public decimal AnnualProfit { get; set; }

        public List<string> ChartLabels { get; set; } = new();
        public List<decimal> ChartValues { get; set; } = new();

    }
}
