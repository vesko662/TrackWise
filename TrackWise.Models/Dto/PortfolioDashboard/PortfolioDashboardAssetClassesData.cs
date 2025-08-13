using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDashboard
{
    public class PortfolioDashboardAssetClassesData
    {
        public List<string> Labels { get; set; } = new();
        public List<decimal> Percents { get; set; } = new();
    }
}
