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
        public ActionResult<ICoinJar> AddCoin(Coin coin)
        {
            try
            {
                this._coinJar.AddCoin(coin);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            return Ok(_coinJar);
        }


        [HttpGet]
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


        [HttpGet]
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
