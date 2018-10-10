using System;

namespace Jilvero.Stocks.WindowsService.Stocks.Handelsbanken
{
    public class HandelsbankenContext : IHandelsbankenContext
    {
        public Stock A { get; set; } = new Stock("SSE340", "SHB-A.ST");
        public Stock B { get; set; } = new Stock("SSE341", "SHB-B.ST");

        private static Stock _lastNotifiedStock;

        public bool IsReady()
        {
            return A.LatestPrice != null && B.LatestPrice != null;
        }

        public bool HasSwapped()
        {
            if (A.LatestPrice == null || B.LatestPrice == null)
            {
                throw new Exception("Not ready");
            }

            if (Math.Abs(A.LatestPrice.Value - B.LatestPrice.Value) < 0.8m)
            {
                return false;
            }

            var currentMostWorth = A.LatestPrice > B.LatestPrice ? A : B;
            if (currentMostWorth.Equals(_lastNotifiedStock))
            {
                return false;
            }

            _lastNotifiedStock = currentMostWorth;
            return true;
        }

        public void Clear()
        {
            _lastNotifiedStock = null;
        }

        public decimal GetDifference()
        {
            if (A.LatestPrice > B.LatestPrice)
            {
                return decimal.Divide(A.LatestPrice.Value, B.LatestPrice.Value) - 1;
            }

            if (B.LatestPrice > A.LatestPrice)
            {
                return decimal.Divide(B.LatestPrice.Value, A.LatestPrice.Value) - 1;
            }

            if (B.LatestPrice == A.LatestPrice)
            {
                return 0;
            }

            throw new Exception("Could not calc diff");
        }
    }
}