using System.Net.Http.Headers;

namespace Clalit_Zeev.Helpers
{
    public static class CreateHttpClient
    {
        public static HttpClient InitializeClient(string url)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);

                // Add headers for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/xml"));

                return client;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
