using Clalit_Zeev.DTOs;
using Clalit_Zeev.Helpers;
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

            xmldoc = XmlUtils.CheckForSingleExchangeRateNode(xmldoc);

            var listResults = XmlUtils.DeserializeData(xmldoc);

            if (listResults == null)
            {
                return new List<ExchangeRateResponseDTO>();
            }

            return listResults.Where(x => x.CurrentChange < 0).ToList();
        }
    }
}
