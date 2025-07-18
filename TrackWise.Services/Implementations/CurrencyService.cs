using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           return currencyRepository.GetAll().Select(s=>mapper.Map<CurrencyDto>(s)).ToList();
        }
    }
}
