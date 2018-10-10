namespace Jilvero.Stocks.WindowsService.Stocks.Handelsbanken
{
    public interface IHandelsbankenContext
    {
        Stock A { get; set; }
        Stock B { get; set; }

        bool HasSwapped();
        bool IsReady();
        void Clear();
        decimal GetDifference();
    }
}