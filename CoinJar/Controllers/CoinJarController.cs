using System;
using System.Collections.Generic;
using CoinJar.DataModels.Models;
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
            coinJar.AddCoin(new Coin() { Amount = 1, Volume = 0.00845350563972975M });
            coinJar.AddCoin(new Coin() { Amount = 1, Volume = 0.00845350563972975M });
            //END FOR TEST PURPOSES

            if (_coinJar != null)
            {
                _coinJar = coinJar;
            }
            else
            {
                throw new ArgumentNullException("coinJar cannot be null.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> AddCoin()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
