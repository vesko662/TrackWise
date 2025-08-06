using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.ApiResponse
{
    public class CoinGeckoMarketChartResponse
    {
        public List<List<JsonElement>> Prices { get; set; }
    }
}
