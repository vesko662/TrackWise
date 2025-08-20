using System.Text.Json;


namespace TrackWise.Models.Dto.ApiResponse
{
    public class CoinGeckoMarketChartResponse
    {
        public List<List<JsonElement>> Prices { get; set; }
    }
}
