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
        [Required]
        public string AssetId { get; set; }
        [Required]
        public TransactionType Type { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
