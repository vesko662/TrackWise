using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Enums;

namespace TrackWise.Models.Dto.AssetDtos
{
    public class AssetSeedDto
    {
        public string Id { get; set; }
        public string Symbol {  get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public AssetType Type { get; set; }
    }
}
