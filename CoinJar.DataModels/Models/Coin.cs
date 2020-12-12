using CoinJar.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.DataModels.Models
{
    public class Coin : ICoin
    {
        public decimal Amount { get;set; }
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
