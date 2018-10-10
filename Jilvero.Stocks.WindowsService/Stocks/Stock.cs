namespace Jilvero.Stocks.WindowsService.Stocks
{
    public class Stock
    {
        public Stock(string nasdaqTicker, string yahooTicker)
        {
            NasdaqTicker = nasdaqTicker;
            YahooTicker = yahooTicker;
        }

        public string NasdaqTicker { get; }
        public string YahooTicker { get; set; }
        public decimal? LatestPrice { get; set; }
    }
}