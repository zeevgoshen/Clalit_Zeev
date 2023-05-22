using Clalit_Zeev.Services;

namespace Clalit_Zeev.Tests
{
    public class ExchangeRatesService_Test
    {
        IExchangeRatesService exchangeRatesService;

        public ExchangeRatesService_Test(IExchangeRatesService exchangeRatesService)
        {
            this.exchangeRatesService = exchangeRatesService;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            exchangeRatesService.GetExchangeRatesAsync();
            Assert.Pass();
        }
    }
}