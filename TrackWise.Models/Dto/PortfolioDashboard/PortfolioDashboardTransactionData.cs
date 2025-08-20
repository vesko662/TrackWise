
namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardTransactionData
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; } 
        public string AssetSymbol { get; set; } 
        public string AssetName { get; set; } 
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }       
    }
}
