using System.ComponentModel.DataAnnotations;

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
