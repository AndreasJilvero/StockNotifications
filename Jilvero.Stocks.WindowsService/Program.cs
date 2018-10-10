using Jilvero.Stocks.WindowsService.App.IoC;
using Jilvero.Stocks.WindowsService.Jobs;
using Quartz;
using StructureMap;
using Topshelf;
using Topshelf.Quartz.StructureMap;
using Topshelf.StructureMap;

namespace Jilvero.Stocks.WindowsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Container.For<AppRegistry>();

            HostFactory.Run(hc =>
            {
                hc.UseStructureMap(container);

                hc.Service<DummyService>(sc =>
                {
                    sc.ConstructUsing(() => new DummyService());
                    sc.WhenStarted(notifier => { });
                    sc.WhenStopped(notifier => { });

                    sc.UseQuartzStructureMap();

                    sc.ScheduleQuartzJob(qc => qc
                        .WithJob(() => JobBuilder.CreateForAsync<HandelsbankenSwapper>().Build())
                        .AddTrigger(() => TriggerBuilder.Create().WithSimpleSchedule(ss => ss.WithIntervalInMinutes(1).RepeatForever()).Build())
                    );

                    sc.ScheduleQuartzJob(qc => qc
                        .WithJob(() => JobBuilder.Create<ClearHandelsbankenJob>().Build())
                        .AddTrigger(() => TriggerBuilder.Create().WithSimpleSchedule(ss => ss.WithIntervalInHours(1).RepeatForever()).Build()));
                });

                hc.RunAsLocalSystem();

                hc.SetDescription("Toasts a notification whenever the A and B stock of Handelsbanken has a difference of over 0.8 SEK.");
                hc.SetDisplayName("Handelsbanken swap notifier");
                hc.SetServiceName("HandelsbankenSwapNotifier");
            });
        }
    }
}
