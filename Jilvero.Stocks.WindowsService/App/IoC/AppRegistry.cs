using Jilvero.Stocks.WindowsService.Stocks.Handelsbanken;
using StructureMap;

namespace Jilvero.Stocks.WindowsService.App.IoC
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            For<IHandelsbankenContext>().Singleton().Use<HandelsbankenContext>();
        }
    }
}