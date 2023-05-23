using Clalit_Zeev.Controllers;
using Clalit_Zeev.Services;

namespace Clalit_Zeev.Tests;

public class ExchangeRatesService_Tests
{
    [Fact]
    public async void ExchangeRatesService_Success()
    {
        //Arrange

        ExchangeRatesService service = new ExchangeRatesService();

        ExchangeRatesController exrc = new ExchangeRatesController(service);

        //Act
        var results = await exrc.GetExchangeRates();


        //Assert
        Assert.NotNull(results);
    }
}