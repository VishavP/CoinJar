using CoinJar.Logic.Implementation;
using CoinJar.Logic.Interfaces;
using NUnit.Framework;
using System;

namespace Tests.UnitTests
{
    public class Given_empty_coinJar
    {
        private static CoinJar.Logic.Implementation.CoinJar _coinJar;

        [SetUp]
        public void Setup() => _coinJar = new CoinJar.Logic.Implementation.CoinJar();

        [Test]
        public void when_adding_valid_coin_to_coinJar_should_not_throw_exception()
        {
            Coin coin = new Coin() { Amount=1};
            Assert.DoesNotThrow(() => { _coinJar.AddCoin(coin); });
        }

        [Test]
        public void When_adding_invalid_coin_to_coinJar_should_throw_correct_exception()
        {
            Coin coin = new Coin() { Amount = 99 };
            Assert.Throws<InvalidOperationException>(() => _coinJar.AddCoin(coin));
        }

        [Test]
        public void when_adding_to_a_full_coinJar()
        {
            while(_coinJar.GetTotalVolume()<41.5M)
            {
                _coinJar.AddCoin(new Coin() { Amount=0.5M});
            }

            var ex = Assert.Throws<InvalidOperationException>(() => _coinJar.AddCoin(new Coin() { Amount=1}));
            Assert.That(ex.Message.Equals("Coinjar is full. Cannot add coin: 1USD"));
        }


        [TearDown]
        public void OnTestTearDown() => _coinJar = new CoinJar.Logic.Implementation.CoinJar();
    }
}