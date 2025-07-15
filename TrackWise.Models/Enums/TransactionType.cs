using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackWise.Models.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Buy")]
        Buy = 1,

        [Display(Name = "Sell")]
        Sell = 2,

    }
}
