using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Dto.CurrencyDto;
using TrackWise.Services.Interfaces;

namespace TrackWise.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IMapper mapper;
        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper, IPortfolioRepository portfolioRepository)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
            this.portfolioRepository = portfolioRepository;
        }
        public IEnumerable<CurrencyDto> GetAll()
        {
            return currencyRepository.GetAll().Select(mapper.Map<CurrencyDto>).ToList();
        }

        public CurrencyDto GetCurrency(string portfolioId)
        {
            var portfolio = portfolioRepository.GetWhere(x => x.Id == portfolioId).FirstOrDefault();
            var currency = currencyRepository.GetWhere(x => x.Id == portfolio.CurrencyId).FirstOrDefault();
            return mapper.Map<CurrencyDto>(currency);
        }

        public async Task<decimal> GetCurrencyRateAsync(string currencyCode)
        {
            if (currencyCode == "USD")
                return 1m;

            string url = $"https://api.frankfurter.app/latest?from=USD&to={currencyCode}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JObject.Parse(response);

                decimal rate = data["rates"][currencyCode].Value<decimal>();
                return rate;
            }
        }
        public char GetCurrencySymbol(string currencyCode)
        {
            return currencyRepository.Get(x=>x.Code==currencyCode).Symbol;
        }
    }
}
