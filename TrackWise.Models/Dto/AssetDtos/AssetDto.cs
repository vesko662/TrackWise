using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;

namespace TrackWise.Models.Dto.AssetDtos
{
    public class AssetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
    }
}
