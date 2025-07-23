using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Models.Enums;

namespace TrackWise.Models.Entities
{
    public class Asset
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public AssetType Type { get; set; }
        public string ExchangeId { get; set; }
        public Exchange Exchange { get; set; }


        public ICollection<Holding> Holdings { get; set; } = new List<Holding>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Price> Prices { get; set; } = new List<Price>();
    }
}
