using Clalit_Zeev.DTOs;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Clalit_Zeev.Helpers
{
    public static class XmlUtils
    {
        public static XmlDocument ForceSingleExchangeRateNodeToArray(XmlDocument xmldoc)
        {
            var exchangeRateResponse = xmldoc.GetElementsByTagName("ExchangeRateResponseDTO");

            if (exchangeRateResponse.Count == 1)
            {
                var attribute = xmldoc.CreateAttribute("json", "Array", "http://james.newtonking.com/projects/json");
                attribute.InnerText = "true";
                var node = exchangeRateResponse.Item(0) as XmlElement;
                node?.Attributes.Append(attribute);
            }

            return xmldoc;
        }

        public static List<ExchangeRateResponseDTO> DeserializeData(XmlDocument xmldoc)
        {
            xmldoc = ForceSingleExchangeRateNodeToArray(xmldoc);

            var elem = xmldoc?.DocumentElement?.ChildNodes[0];
            var fromXml = JsonConvert.SerializeXmlNode(elem);
            var fromJson = JsonConvert.
                DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);

            if (fromJson == null ||
                fromJson.ExchangeRates == null ||
                fromJson.ExchangeRates.ExchangeRateResponseDTO == null)
            {
                return new List<ExchangeRateResponseDTO>();
            }

            return fromJson.ExchangeRates.ExchangeRateResponseDTO.ToList();
        }
    }
}
