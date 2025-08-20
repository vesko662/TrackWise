using System.ComponentModel.DataAnnotations;

namespace TrackWise.Models.Entities
{
    public class Currency
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public char Symbol { get; set; }

        public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
