using TrackWise.Models.Dto.CurrencyDto;

namespace TrackWise.Services.Interfaces
{
    public interface ICurrencyService
    {
        public IEnumerable<CurrencyDto> GetAll();
        public char GetCurrencySymbol(string currencyCode);
        public CurrencyDto GetCurrency(string portfolioId);
        public Task<decimal> GetCurrencyRateAsync(string currencyCode);

    }
}
