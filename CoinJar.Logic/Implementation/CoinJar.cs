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
        //below coin weight in grams as listed on wikipedia, volumes calculated using an online converter
        //which can be found at https://www.convertunits.com/from/g/to/fl+oz
        //penny(1 cent) - volume: 0.00845350563972975M, 
        //nickel(5 cent) - volume: 0.169070112794595M, 
        //dime(10 cent) - volume: 0.07669020316362829M, 
        //quarter dollar(25 cent) - volume: 0.19172550790907072M, 
        //half dollar(50 cent) -volume: 0.38345101581814145M
        //and dollar coins - volume: 0.2738935827272439M
        private static List<ICoin> _coins;

        public CoinJar()
        {
            _coins = new List<ICoin>();
        }

        public void AddCoin(ICoin coin)
        {
            if (coin.IsValidCoin() && _coins.Sum(x=>x.Volume)+coin.Volume <= 42)
            {
                switch(coin.Amount)
                {
                    case 0.01M:
                        coin.Volume = 0.00845350563972975M;
                        break;

                    case 0.05M:
                        coin.Volume = 0.169070112794595M;
                        break;

                    case 0.10M:
                        coin.Volume = 0.07669020316362829M;
                        break;

                    case 0.25M:
                        coin.Volume = 0.19172550790907072M;
                        break;

                    case 0.50M:
                        coin.Volume = 0.38345101581814145M;
                        break;

                    case 1:
                        coin.Volume = 0.2738935827272439M;
                        break;
                }
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
