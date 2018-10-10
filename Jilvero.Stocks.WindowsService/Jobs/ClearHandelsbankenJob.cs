using System.Threading.Tasks;
using Jilvero.Stocks.WindowsService.Stocks.Handelsbanken;
using Quartz;

namespace Jilvero.Stocks.WindowsService.Jobs
{
    public class ClearHandelsbankenJob : IJob
    {
        private readonly IHandelsbankenContext _context;

        public ClearHandelsbankenJob(IHandelsbankenContext context)
        {
            _context = context;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _context.Clear();
            return Task.FromResult(0);
        }
    }
}