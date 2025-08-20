using System;
using System.Collections.Generic;

namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardViewModel
    {
        public PortfolioDashboardChartData ChartData { get; set; }
        public IEnumerable<PortfolioDashboardHoldingData> HoldingData { get; set; }
        public IEnumerable<PortfolioDashboardTransactionData> TransactionData { get; set; }
        public PortfolioDashboardAssetClassesData AssetClassesData { get; set; }
    }
}
