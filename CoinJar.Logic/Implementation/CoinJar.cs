using CoinJar.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CoinJar.Logic.Implementation
{
    public class CoinJar : ICoinJar, IDisposable
    {
        private static List<ICoin> _coins;

        public CoinJar()
        {
            _coins = new List<ICoin>();
        }

        public void AddCoin(ICoin coin)
        {
            if (coin.IsValidCoin() && _coins.Sum(x=>x.Volume)+coin.Volume <= 42)
            {
                _coins.Add(coin);
            }
        }

        public decimal GetTotalAmount()
        {
            return _coins.Sum(x =>x.Amount);
        }

        public void Reset()
        {
            _coins = new List<ICoin>();
        }

        public void Dispose()
        {
            Reset();
            GC.SuppressFinalize(true);
        }
    }
}
