using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.ApiResponse
{
    public class FmpSymbolResponse
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string ExchangeShortName { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }
    }
}
