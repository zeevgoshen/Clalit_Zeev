using System.Xml;

namespace Clalit_Zeev.Helpers
{
    public static class XmlUtils
    {
        public static XmlDocument CheckForSingleExchangeRateNode(XmlDocument xmldoc)
        {
            var exchangeRateResponse = xmldoc.GetElementsByTagName("ExchangeRateResponseDTO");

            if (exchangeRateResponse.Count == 1)
            {
                var attribute = xmldoc.CreateAttribute("json", "Array", "http://james.newtonking.com/projects/json");
                attribute.InnerText = "true";
                var node = exchangeRateResponse.Item(0) as XmlElement;
                node.Attributes.Append(attribute);
            }

            return xmldoc;
        }
    }
}
