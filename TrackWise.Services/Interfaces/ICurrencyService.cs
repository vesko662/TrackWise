using TrackWise.Models.Dto.CurrencyDto;

namespace TrackWise.Services.Interfaces
{
    public interface ICurrencyService
    {
        public IEnumerable<CurrencyDto> GetAll();
    }
}
