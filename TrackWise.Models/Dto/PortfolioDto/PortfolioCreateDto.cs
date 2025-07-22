using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDto
{
    public class PortfolioCreateDto
    {
        public string Name { get; set; } = null!;
        public string CurrencyId { get; set; }
    }
}
