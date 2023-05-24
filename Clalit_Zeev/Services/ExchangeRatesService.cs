using Clalit_Zeev.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Xml;

namespace Clalit_Zeev.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExchangeRatesService(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<List<ExchangeRateResponseDTO>?> GetExchangeRatesAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("Clalit");

                // Get data response
                var response = await httpClient.GetAsync("/PublicApi/GetExchangeRates?asXML=true");

                var filteredResults = new List<ExchangeRateResponseDTO>();

                if (response.IsSuccessStatusCode)
                {
                    //// Parse the response body
                    var dataObjects = await response.Content.ReadAsStringAsync();

                    if (dataObjects != null)
                    {
                        filteredResults = ReturnNegativeChangeJson(dataObjects);
                    }
                }
                return filteredResults;
            }
            catch (Exception)
            {
                return new List<ExchangeRateResponseDTO>();
            }
        }

        private List<ExchangeRateResponseDTO> ReturnNegativeChangeJson(
            string dataObjects)
        {
            
            var filteredResults = new List<ExchangeRateResponseDTO>();
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(dataObjects);

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

            if (fromJson != null &&
                fromJson.ExchangeRates != null
                && fromJson.ExchangeRates.ExchangeRateResponseDTO != null)
            {
                return fromJson.ExchangeRates.ExchangeRateResponseDTO
                    .Where(x => x.CurrentChange < 0).ToList();
            }
            return new List<ExchangeRateResponseDTO>();
        }
    }
}
