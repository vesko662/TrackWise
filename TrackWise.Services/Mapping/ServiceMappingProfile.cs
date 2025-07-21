using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.CurrencyDto;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Entities;

namespace TrackWise.Services.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            //Portfolio mappings
            CreateMap<Portfolio, PortfolioDto>()
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Currency.Code));

            CreateMap<PortfolioCreateDto, Portfolio>();
            CreateMap<Portfolio, PortfolioUpdateDto>();
            CreateMap<PortfolioUpdateDto, Portfolio>();

            // Currency mappings
            CreateMap<Currency, CurrencyDto>();

        }
    }
}
