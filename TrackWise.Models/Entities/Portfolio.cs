using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Entities
{
    public class Portfolio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Holding> Holdings { get; set; } = new List<Holding>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
