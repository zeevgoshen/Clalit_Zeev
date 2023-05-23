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
        private List<ExchangeRateResponseDTO> results = new List<ExchangeRateResponseDTO>();

        public async Task<IEnumerable<ExchangeRateResponseDTO>?> GetExchangeRatesAsync()
        {
            try
            {
                var client = CreateHttpClient.InitializeClient(url);

                // Get data response
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //// Parse the response body
                    var dataObjects = await response.Content.ReadAsStringAsync();

                    if (dataObjects != null)
                    {
                        ReturnNegativeChangeJson(dataObjects);
                    }
                }
                return results;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ReturnNegativeChangeJson(string dataObjects)
        {
            try
            {
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

                results.AddRange(from node in fromJson?.ExchangeRates?.ExchangeRateResponseDTO
                                 where node.CurrentChange < 0
                                 select node);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
