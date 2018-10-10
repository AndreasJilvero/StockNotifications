using Newtonsoft.Json;

namespace Jilvero.Stocks.WindowsService.Http.Json
{
    public class NasdaqInstrument
    {
        [JsonProperty("@ltp")]
        public decimal LatestPrice { get; set; }
    }
}