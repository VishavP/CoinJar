using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Logic.Interfaces
{
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }
}
