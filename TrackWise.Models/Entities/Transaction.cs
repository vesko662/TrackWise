using System.ComponentModel.DataAnnotations;
using TrackWise.Models.Enums;


namespace TrackWise.Models.Entities
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public string AssetId { get; set; }
        public Asset Asset { get; set; }

        [Required]
        public TransactionType Type { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
