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
    }
}
