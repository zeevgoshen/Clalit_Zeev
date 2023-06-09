﻿using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Clalit_Zeev.DTOs
{
    public class ExchangeRate
    {
        public List<ExchangeRateResponseDTO>? ExchangeRateResponseDTO { get; set; }
    }
    
    public class ExchangeRateResponseDTO
    {
        public double CurrentChange { get; set; }
        public double CurrentExchangeRate { get; set; }
        public string? Key { get; set; }
        public string? LastUpdate { get; set; }
        public string? Unit { get; set; }
    }

    public class ExchangeRatesResponseCollectioDTO
    {
        public ExchangeRate? ExchangeRates { get; set; }
    }

    public class Root
    {
        public ExchangeRatesResponseCollectioDTO? ExchangeRatesResponseCollectioDTO { get; set; }
    }
}
