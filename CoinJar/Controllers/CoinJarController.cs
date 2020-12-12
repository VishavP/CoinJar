using System;
using CoinJar.Logic.Implementation;
using CoinJar.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoinJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private ICoinJar _coinJar;

        public CoinJarController(ICoinJar coinJar)
        {
            //FOR TEST PURPOSES...
            coinJar = new Logic.Implementation.CoinJar();
            coinJar.AddCoin(new Coin() { Amount = 1, Volume= 0.00845350563972975M });
            coinJar.AddCoin(new Coin() { Amount = 1, Volume = 0.00845350563972975M });
            coinJar.AddCoin(new Coin() { Amount = 1, Volume = 0.00845350563972975M });
            //END FOR TEST PURPOSES
                
            if (coinJar != null)
            {
                _coinJar = coinJar;
            }
            else
            {
                throw new ArgumentNullException("coinJar cannot be null.");
            }
        }

        [HttpPost]
        ///<remarks>
        ///Adds a coin to the coinjar
        ///</remarks>
        public ActionResult<ICoinJar> AddCoin(decimal amount)
        {
            try
            {
                Coin coin = new Coin() { Amount = amount };
                this._coinJar.AddCoin(coin);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            return Ok(_coinJar);
        }


        [HttpGet]
        ///<remarks>
        ///Gets the total amount of money in the coinjar
        ///</remarks>
        public ActionResult<decimal> GetTotalAmount()
        {
            try
            {
                return Ok(_coinJar.GetTotalAmount());
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut]
        ///<remarks>
        ///resets the coinJar
        ///</remarks>
        public ActionResult Reset()
        {
            try
            {
                _coinJar.Reset();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
