using AutoMapper;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.CurrencyDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMapper mapper;
        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }
        public IEnumerable<CurrencyDto> GetAll()
        {
           return currencyRepository.GetAll().Select(mapper.Map<CurrencyDto>).ToList();
        }
    }
}
