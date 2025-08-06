using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.ApiResponse
{
    public class FmpHistoricalPriceResponse
    {
        public string Symbol { get; set; }
        public List<FmpHistoricalPrice> Historical { get; set; }
    }
}
