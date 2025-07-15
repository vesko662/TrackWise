using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Enums
{
    public enum AssetType
    {

        [Display(Name = "Stock")]
        Stock = 1,

        [Display(Name = "Cryptocurrency")]
        Crypto = 2,

        [Display(Name = "Exchange Traded Fund")]
        ETF = 3,

        [Display(Name = "Mutual Fund")]
        Fund = 4,

        [Display(Name = "Bond")]
        Bond = 5,

        [Display(Name = "Commodity")]
        Commodity = 6,

        [Display(Name = "Index")]
        Index = 7,

        [Display(Name = "Real Estate Investment Trust")]
        REIT = 8,

        [Display(Name = "Currency (Fiat)")]
        FiatCurrency = 9,

        [Display(Name = "Option")]
        Option = 10,

        [Display(Name = "Futures Contract")]
        Futures = 11
    }
}
