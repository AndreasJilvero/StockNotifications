using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jilvero.Stocks.WindowsService.Http.Json;
using Jilvero.Stocks.WindowsService.Stocks;
using Jilvero.Stocks.WindowsService.Stocks.Handelsbanken;
using Newtonsoft.Json;

namespace Jilvero.Stocks.WindowsService.Http
{
    public class YahooWebService
    {
        public async Task UpdateLastPrice(Stock stock)
        {
            using (var httpClient = new HttpClient {BaseAddress = new Uri("https://query1.finance.yahoo.com/v7/finance/") })
            {
                var httpResponse = await httpClient.GetAsync($"quote?symbols={stock.YahooTicker}");
                httpResponse.EnsureSuccessStatusCode();
                var httpContent = await httpResponse.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<YahooResponseModel>(httpContent);
                stock.LatestPrice = responseModel.QuoteResponse.Result.Single().RegularMarketPrice;
            }
        }
    }
}