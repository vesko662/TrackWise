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
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public string CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Holding> Holdings { get; set; } = new List<Holding>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
