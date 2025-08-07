using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardViewModel
    {
        public string PortfolioId { get; set; }

        public decimal TotalValue { get; set; }
        public decimal AnnualReturn { get; set; }
        public decimal AnnualProfit { get; set; }

        public List<string> ChartLabels { get; set; } = new List<string>();
        public List<decimal> ChartValues { get; set; } = new List<decimal>();

        public string ViewMode { get; set; } 
        public string SelectedPeriod { get; set; }
        public List<string> AvailablePeriods { get; set; } = new() { "From the beginning"};

    }
}
