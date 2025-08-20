using System;

namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardHoldingData
    {
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public int HoldingPeriodDays { get; set; }
        public decimal CumulativeCashflow { get; set; }
        public decimal CumulativeCashflowPerShare { get; set; }
        public decimal MarketValue { get; set; }
        public decimal LastPrice { get; set; }
        public decimal PriceReturnPercent { get; set; }
        public decimal NetProfitLossPercent { get; set; }
        public decimal AllocationPercent { get; set; }
    }
}
