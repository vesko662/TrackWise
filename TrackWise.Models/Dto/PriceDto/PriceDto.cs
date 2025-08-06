using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Dto.PriceDto
{
    public class PriceDto
    {
        public string AssetId { get; set; }
        public DateTime Date { get; set; }
        public decimal HistoryPrice { get; set; }
    }
}
