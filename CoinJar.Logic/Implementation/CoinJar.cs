using CoinJar.Logic.Interfaces;
using System;
using System.Collections.Generic;
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
            _coins.Add(coin);
        }

        public decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach(var c in _coins)
            {
                sum += c.Amount;
            }
            return sum;
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
