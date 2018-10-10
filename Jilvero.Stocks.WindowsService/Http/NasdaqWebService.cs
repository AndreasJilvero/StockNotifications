using System;
using System.Net.Http;
using System.Threading.Tasks;
using Jilvero.Stocks.WindowsService.Http.Json;
using Jilvero.Stocks.WindowsService.Stocks;
using Jilvero.Stocks.WindowsService.Stocks.Handelsbanken;
using Newtonsoft.Json;

namespace Jilvero.Stocks.WindowsService.Http
{
    public class NasdaqWebService
    {
        public async Task UpdateLastPrice(Stock stock)
        {
            using (var httpClient = new HttpClient {BaseAddress = new Uri("http://www.nasdaqomxnordic.com/webproxy/")})
            {
                var httpResponse = await httpClient.GetAsync($"DataFeedProxy.aspx?SubSystem=Prices&Action=GetInstrument&Source=OMX&Instrument={stock.NasdaqTicker}&inst.an=ltp&json=1");
                httpResponse.EnsureSuccessStatusCode();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var nasdaqResponse = JsonConvert.DeserializeObject<NasdaqResponse>(content);
                stock.LatestPrice = nasdaqResponse.Instrument.LatestPrice;
            }
        }
    }
}