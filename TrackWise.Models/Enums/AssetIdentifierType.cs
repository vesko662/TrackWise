using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Enums
{
    public enum AssetIdentifierType
    {
        [Display(Name = "ISIN")]
        ISIN = 1,

        [Display(Name = "CUSIP")]
        CUSIP = 2,

        [Display(Name = "US ticker")]
        Ticker = 3,

        [Display(Name = "Option contract")]
        Option = 4,

        [Display(Name = "Cryptocurrency")]
        CryptoSymbol = 5
    }
}
