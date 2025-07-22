using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Entities;
using TrackWise.Models.Enums;

namespace TrackWise.Models.Dto.TransactionDtos
{
    public class TransactionCreateDto
    {
        public string PortfolioId { get; set; }
        public string AssetId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
    }
}
