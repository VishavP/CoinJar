using CoinJar.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoinJar.DataModels.Models
{
    //Present day United States coins. 
    //penny(1 cent) - volume: 0.00845350563972975M, 
    //nickel(5 cent) - volume: 0.169070112794595M, 
    //dime(10 cent) - volume: 0.07669020316362829M, 
    //quarter dollar(25 cent) - volume: 0.19172550790907072M, 
    //half dollar(50 cent) -volume: 0.38345101581814145M
    //and dollar coins - volume: 0.2738935827272439M

    public class Coin : ICoin
    {
        [Required]
        public decimal Amount { get;set; }
        [Required]
        public decimal Volume { get;set; }

        public bool IsValidCoin()
        {
            List<decimal> acceptableValues = new List<decimal>() { 1, 10, 25, 50, 1 };
            if (this == null)
            {
                return false;
            }
            else if (!acceptableValues.Contains(this.Amount))
            {
                return false;
            }
            return true;
        }
    }
}
