using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Entities
{
    public class Exchange
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
