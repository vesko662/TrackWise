
namespace TrackWise.Models.Dto.ApiResponse
{
    public class FmpHistoricalPriceResponse
    {
        public string Symbol { get; set; }
        public List<FmpHistoricalPrice> Historical { get; set; }
    }
}
