using Clalit_Zeev.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using Clalit_Zeev.Helpers;

namespace Clalit_Zeev.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private string url = "https://boi.org.il/PublicApi/GetExchangeRates?asXML=true";

        public async Task<IEnumerable<ExchangeRateResponseDTO>?> GetExchangeRatesAsync()
        {
            try
            {
                var httpClient = CreateHttpClient.InitializeClient(url);

                // Get data response
                var response = await httpClient.GetAsync(url);
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

        public List<ExchangeRateResponseDTO> ReturnNegativeChangeJson(
            string dataObjects)
        {
            try
            {
                var filteredResults = new List<ExchangeRateResponseDTO>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(dataObjects);

                var elem = xmldoc?.DocumentElement?.ChildNodes[0];
                var fromXml = JsonConvert.SerializeXmlNode(elem);
                var fromJson = JsonConvert.DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);

                //foreach(var node in fromJson?.ExchangeRates.ExchangeRateResponseDTO)
                //{
                //    if (node.CurrentChange < 0)
                //    {
                //        results.Add(node);
                //    }
                //}

                filteredResults.AddRange(from node in fromJson?.ExchangeRates?.ExchangeRateResponseDTO
                                 where node.CurrentChange < 0
                                 select node);

                return filteredResults;
            }
            catch (Exception)
            {
                return new List<ExchangeRateResponseDTO>();
            }
        }
    }
}
