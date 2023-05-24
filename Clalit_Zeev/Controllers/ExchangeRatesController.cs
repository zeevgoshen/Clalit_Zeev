using Clalit_Zeev.DTOs;
using Clalit_Zeev.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clalit_Zeev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesService service;

        public ExchangeRatesController(
            IExchangeRatesService service)
        {
            this.service = service;
        }

        [HttpGet(Name = "ExchangeRates")]
        public async Task<IEnumerable<ExchangeRateResponseDTO>> GetExchangeRates()
        {
            return await service.GetExchangeRatesAsync();
        }
    }
}
