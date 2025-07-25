﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Dto.ApiResponse;
using TrackWise.Models.Dto.AssetDtos;
using TrackWise.Models.Dto.CurrencyDto;
using TrackWise.Models.Dto.PortfolioDto;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;

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

            //Asset mappings
            CreateMap<FmpSymbolResponse, AssetSeedDto>()
                .ForMember(dest => dest.Type, opt => opt
                    .MapFrom(src => src.Type == "stock" ? AssetType.Stock : AssetType.ETF));

            CreateMap<CoinGeckoResponse, AssetSeedDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AssetType.Crypto));

            CreateMap<Asset,AssetDto>();

        }
    }
}
