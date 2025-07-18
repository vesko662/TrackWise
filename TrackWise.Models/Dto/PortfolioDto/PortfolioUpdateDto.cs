using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PortfolioDto
{
    public class PortfolioUpdateDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Guid CurrencyId { get; set; }
    }
}
