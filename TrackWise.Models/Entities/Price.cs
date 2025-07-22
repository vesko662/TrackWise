using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Entities
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public string AssetId { get; set; }
        public Asset Asset { get; set; } = null!;
        public DateTime Date { get; set; }
        [Required]
        public decimal HistoryPrice { get; set; }
    }
}
