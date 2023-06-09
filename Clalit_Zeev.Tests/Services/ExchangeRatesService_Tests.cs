using Clalit_Zeev.Controllers;
using Clalit_Zeev.DTOs;
using Clalit_Zeev.Helpers;
using Clalit_Zeev.Tests.TestData;
using System.Xml;

namespace Clalit_Zeev.Tests.Services;

public class ExchangeRatesService_Tests
{
    
    [Fact]
    public void ReturnNegativeChangeJson_PARSE_EXPECTED_XML_VALUES_SUCCESS()
    {
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(StaticTestData.xml2);

        var listResults = XmlUtils.DeserializeData(xmldoc);

        var currentChange = listResults?[0].CurrentChange;
        var currentExchangeRate = listResults?[0].CurrentExchangeRate;
        var key = listResults?[0].Key;
        var lastUpdate = listResults?[0].LastUpdate;
        var unit = listResults?[0].Unit;


        Assert.Equal(2, listResults?.Count());
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

        var listResults = XmlUtils.DeserializeData(xmldoc);

        var results = listResults?.Where(x => x.CurrentChange < 0).ToList();

        Assert.Single(results);
    }

    [Fact]
    public void ReturnNegativeChangeJson_EXPECT_1_EXCHANGE_RECORD_SUCCESS()
    {
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(StaticTestData.xml1);

        var listResults = XmlUtils.DeserializeData(xmldoc);

        Assert.Single(listResults);
    }
}