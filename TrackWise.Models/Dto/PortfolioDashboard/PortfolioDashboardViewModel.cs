using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardViewModel
    {
        public PortfolioDashboardChartData ChartData { get; set; }
        public IEnumerable<PortfolioDashboardHoldingData> HoldingData { get; set; }
        public PortfolioDashboardTransactionData TransactionData { get; set; }
        public PortfolioDashboardAssetClassesData AssetClassesData { get; set; }
    }
}
