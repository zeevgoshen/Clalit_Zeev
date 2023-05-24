using Clalit_Zeev.DTOs;

namespace Clalit_Zeev.Services
{
    public interface IExchangeRatesService
    {
        public Task<List<ExchangeRateResponseDTO>?> GetExchangeRatesAsync();
    }
}
