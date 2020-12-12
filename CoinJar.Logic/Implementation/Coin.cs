using CoinJar.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoinJar.Logic.Implementation
{
    public class Coin : ICoin
    {
        [Required]
        public decimal Amount { get;set; }
        
        public decimal Volume { get;set; }

        public bool IsValidCoin()
        {
            List<decimal> acceptableValues = new List<decimal>() { 0.01M, 0.05M, 0.10M, 0.25M, 0.50M, 1 };
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
