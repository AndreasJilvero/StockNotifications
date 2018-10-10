using Newtonsoft.Json;

namespace Jilvero.Stocks.WindowsService.Http.Json
{
    public class NasdaqResponse
    {
        [JsonProperty("inst")]
        public NasdaqInstrument Instrument { get; set; }
    }
}