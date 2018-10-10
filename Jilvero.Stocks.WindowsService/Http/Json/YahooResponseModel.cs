using System.Collections.Generic;

namespace Jilvero.Stocks.WindowsService.Http.Json
{
    public class YahooResponseModel
    {
        public YahooQuoteResponse QuoteResponse { get; set; }
    }

    public class YahooQuoteResponse
    {
        public List<YahooStockModel> Result { get; set; }
    }
}