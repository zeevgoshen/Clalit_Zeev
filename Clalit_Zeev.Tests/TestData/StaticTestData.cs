using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clalit_Zeev.Tests.TestData
{
    public static class StaticTestData
    {
		public static string xmlNegative =
			@"<ExchangeRatesResponseCollectioDTO xmlns:i='http://www.w3.org/2001/XMLSchema-instance'
            xmlns='http://schemas.datacontract.org/2004/07/BOI.Core.Models.HotData'>
				<ExchangeRates>
					<ExchangeRateResponseDTO>
						<CurrentChange>-0.5751848808545603944124897300</CurrentChange>
						<CurrentExchangeRate>3.672</CurrentExchangeRate>
						<Key>USD</Key>
						<LastUpdate>2023-05-23T12:22:04.6850154Z</LastUpdate>
						<Unit>1</Unit>
					</ExchangeRateResponseDTO>
					<ExchangeRateResponseDTO>
						<CurrentChange>0.1290355227203724319400870400</CurrentChange>
						<CurrentExchangeRate>3.9575</CurrentExchangeRate>
						<Key>EUR</Key>
						<LastUpdate>2023-05-23T12:22:04.6850154Z</LastUpdate>
						<Unit>1</Unit>
					</ExchangeRateResponseDTO>
				</ExchangeRates>
            </ExchangeRatesResponseCollectioDTO>";
		
		public static string xml2 =
			@"<ExchangeRatesResponseCollectioDTO xmlns:i='http://www.w3.org/2001/XMLSchema-instance'
            xmlns='http://schemas.datacontract.org/2004/07/BOI.Core.Models.HotData'>
				<ExchangeRates>
					<ExchangeRateResponseDTO>
						<CurrentChange>0.5751848808545603944124897300</CurrentChange>
						<CurrentExchangeRate>3.672</CurrentExchangeRate>
						<Key>USD</Key>
						<LastUpdate>2023-05-23T12:22:04.6850154Z</LastUpdate>
						<Unit>1</Unit>
					</ExchangeRateResponseDTO>
					<ExchangeRateResponseDTO>
						<CurrentChange>0.1290355227203724319400870400</CurrentChange>
						<CurrentExchangeRate>3.9575</CurrentExchangeRate>
						<Key>EUR</Key>
						<LastUpdate>2023-05-23T12:22:04.6850154Z</LastUpdate>
						<Unit>1</Unit>
					</ExchangeRateResponseDTO>
				</ExchangeRates>
            </ExchangeRatesResponseCollectioDTO>";

		public static string xml1 =
			@"<ExchangeRatesResponseCollectioDTO xmlns:i='http://www.w3.org/2001/XMLSchema-instance'
            xmlns='http://schemas.datacontract.org/2004/07/BOI.Core.Models.HotData'>
				<ExchangeRates>
					<ExchangeRateResponseDTO>
						<CurrentChange>0.5751848808545603944124897300</CurrentChange>
						<CurrentExchangeRate>3.672</CurrentExchangeRate>
						<Key>USD</Key>
						<LastUpdate>2023-05-23T12:22:04.6850154Z</LastUpdate>
						<Unit>1</Unit>
					</ExchangeRateResponseDTO>
				</ExchangeRates>
            </ExchangeRatesResponseCollectioDTO>";
	}
}
