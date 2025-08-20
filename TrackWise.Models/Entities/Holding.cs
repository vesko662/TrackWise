using System.ComponentModel.DataAnnotations;

namespace TrackWise.Models.Entities
{
    public class Holding
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public string AssetId { get; set; }
        public Asset Asset { get; set; }

        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal AvgBuyPrice { get; set; }
    }
}
