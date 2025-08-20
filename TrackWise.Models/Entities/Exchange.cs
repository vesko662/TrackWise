using System.ComponentModel.DataAnnotations;

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
