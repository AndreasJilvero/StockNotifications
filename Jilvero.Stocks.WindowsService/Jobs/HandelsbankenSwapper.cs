using System.Management.Automation;
using System.Threading.Tasks;
using Jilvero.Stocks.WindowsService.Http;
using Jilvero.Stocks.WindowsService.Stocks.Handelsbanken;
using Quartz;

namespace Jilvero.Stocks.WindowsService.Jobs
{
    public class HandelsbankenSwapper : IJob
    {
        private readonly IHandelsbankenContext _context;
        private readonly YahooWebService _yahooWebService;

        public HandelsbankenSwapper(IHandelsbankenContext context)
        {
            _context = context;
            _yahooWebService = new YahooWebService();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _yahooWebService.UpdateLastPrice(_context.A);
            await _yahooWebService.UpdateLastPrice(_context.B);

            if (!_context.IsReady())
            {
                return;
            }

            if (_context.HasSwapped())
            {
                var difference = _context.GetDifference();
                var message = $"A-aktien står i {_context.A.LatestPrice:0.00} och B-aktien i {_context.B.LatestPrice:0.00}, en skillnad på {difference:P2}.";

                using (var powershell = PowerShell.Create())
                {
                    powershell.AddScript($"New-BurntToastNotification -Text 'Handelsbanken swap', '{message}'");
                    powershell.Invoke();
                }
            }
        }
    }
}