using Clalit_Zeev.Controllers;
using Clalit_Zeev.DTOs;
using Clalit_Zeev.Services;
using System.Text.Json;

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

    [Fact]
    public void ReturnNegativeChangeJson_JSON_INSTEAD_OF_XML_Throws()
    {
        //Arrange
        var filteredResults = new List<ExchangeRateResponseDTO>();

        var dto1 = new ExchangeRateResponseDTO() { Key = "YYY", CurrentChange = -0.0001, CurrentExchangeRate = 3.8};
        var dto2 = new ExchangeRateResponseDTO() { Key = "YYA", CurrentChange = -0.0011, CurrentExchangeRate = 3.7 };
        var dto3 = new ExchangeRateResponseDTO() { Key = "YYB", CurrentChange = -0.0111, CurrentExchangeRate = 3.6 };
        var dto4 = new ExchangeRateResponseDTO() { Key = "YYC", CurrentChange = 0.0111, CurrentExchangeRate = 3.6 };

        filteredResults.Add(dto1);
        filteredResults.Add(dto2);
        filteredResults.Add(dto3);
        filteredResults.Add(dto4);

        ExchangeRatesService service = new ExchangeRatesService();
        var stringJson = JsonSerializer.Serialize(filteredResults);

        ////Act
        var results = service.ReturnNegativeChangeJson(stringJson);

        //Assert
        Assert.Equal(0, results.Count);
    }
}