using System.ComponentModel.DataAnnotations;

namespace TrackWise.Models.Enums
{
    public enum AssetType
    {
        [Display(Name = "Stock")]
        Stock = 1,

        [Display(Name = "Cryptocurrency")]
        Crypto = 2,

        [Display(Name = "ETF")]
        ETF = 3,

        //[Display(Name = "Currency (Fiat)")]
        //FiatCurrency = 4,
    }
}
