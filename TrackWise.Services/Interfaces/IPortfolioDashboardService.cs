using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.PortfolioDashboard;

namespace TrackWise.Services.Interfaces
{
    public interface IPortfolioDashboardService
    {
        public PortfolioDashboardChartData BuildChartData(string portfolioId);
        public IEnumerable<PortfolioDashboardHoldingData> BuildHoldingData(string portfolioId); 

        public PortfolioDashboardTransactionData BuildTransactionData(string portfolioId);
        public PortfolioDashboardAssetClassesData BuildAssetClassesData(string portfolioId);
    }
}
