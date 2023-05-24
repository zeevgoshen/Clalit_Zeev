using Clalit_Zeev.Controllers;
using Clalit_Zeev.DTOs;
using Clalit_Zeev.Services;
using Clalit_Zeev.Tests.TestData;
using Newtonsoft.Json;
using System.Text.Json;
using System.Xml;

namespace Clalit_Zeev.Tests.Services;

public class ExchangeRatesService_Tests
{

    [Fact]
    public void ReturnNegativeChangeJson_PARSE_EXPECTED_XML_VALUES_SUCCESS()
    {
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(StaticTestData.xml2);

        var elem = xmldoc?.DocumentElement?.ChildNodes[0];
        var fromXml = JsonConvert.SerializeXmlNode(elem);
        var fromJson = JsonConvert.
            DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);

        if (fromJson == null ||
            fromJson.ExchangeRates == null ||
            fromJson.ExchangeRates.ExchangeRateResponseDTO == null)
        {
            // fail assertion on purpose
            Assert.NotNull(null);
        }

        var listResults = fromJson.ExchangeRates.ExchangeRateResponseDTO.ToList();

        var currentChange = listResults[0].CurrentChange;
        var currentExchangeRate = listResults[0].CurrentExchangeRate;
        var key = listResults[0].Key;
        var lastUpdate = listResults[0].LastUpdate;
        var unit = listResults[0].Unit;


        Assert.Equal(2, fromJson.ExchangeRates.ExchangeRateResponseDTO.Count());
        Assert.Equal("USD", key);
        Assert.Equal(0.5751848808545603944124897300, currentChange);
        Assert.Equal(3.672, currentExchangeRate);

        Assert.NotNull(lastUpdate);
        Assert.NotNull(unit);
    }

    [Fact]
    public void ReturnNegativeChangeJson_EXPECT_1_NEGATIVE_VALUE_SUCCESS()
    {
        var filteredResults = new List<ExchangeRateResponseDTO>();
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(StaticTestData.xmlNegative);

        var elem = xmldoc?.DocumentElement?.ChildNodes[0];
        var fromXml = JsonConvert.SerializeXmlNode(elem);
        var fromJson = JsonConvert.
            DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);

        if (fromJson == null ||
            fromJson.ExchangeRates == null ||
            fromJson.ExchangeRates.ExchangeRateResponseDTO == null)
        {
            // fail assertion on purpose
            Assert.NotNull(null);
        }

        var listResults = fromJson.ExchangeRates.ExchangeRateResponseDTO.ToList();

        var results = listResults.Where(x => x.CurrentChange < 0).ToList();

        Assert.Single(results);

    }

    [Fact]
    public void ReturnNegativeChangeJson_EXPECT_1_EXCHANGE_RECORD_SUCCESS()
    {
        var filteredResults = new List<ExchangeRateResponseDTO>();
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(StaticTestData.xml1);
        
        var exchangeRateResponse = xmldoc.GetElementsByTagName("ExchangeRateResponseDTO");

        if (exchangeRateResponse.Count == 1)
        {
            var attribute = xmldoc.CreateAttribute("json", "Array", "http://james.newtonking.com/projects/json");
            attribute.InnerText = "true";
            var node = exchangeRateResponse.Item(0) as XmlElement;
            node.Attributes.Append(attribute);
        }

        var elem = xmldoc?.DocumentElement?.ChildNodes[0];
        var fromXml = JsonConvert.SerializeXmlNode(elem);
        var fromJson = JsonConvert.
            DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);
        

        if (fromJson == null ||
            fromJson.ExchangeRates == null ||
            fromJson.ExchangeRates.ExchangeRateResponseDTO == null)
        {
            // fail assertion on purpose
            Assert.NotNull(null);
        }

        var listResults = fromJson.ExchangeRates.ExchangeRateResponseDTO.ToList();

        Assert.Single(listResults);

    }
}