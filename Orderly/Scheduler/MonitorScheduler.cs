using Microsoft.Extensions.Logging;

using Orderly.Helpers;
using Orderly.Services.Email;
using Orderly.Services.Monitor;
using Orderly.Services.OverTheCounter;
using Orderly.Services.Token;

using Quartz;
using System.Threading.Tasks;

namespace Orderly.Scheduler
{
    [DisallowConcurrentExecution]
    public class MonitorScheduler : IJob
    {
        private readonly ILogger<MonitorScheduler> _logger;
        private readonly IMonitoringService _monitoringService;
        private readonly IQueuedEmailService _emailService;
        private readonly INetworkTokenService _networkTokenService;
        private readonly IOTCService _otcService;

        public MonitorScheduler(
            ILogger<MonitorScheduler> logger,
            IMonitoringService monitoringService,
            IQueuedEmailService emailService,
            INetworkTokenService networkTokenService,
            IOTCService otcService)
        {
            _logger = logger;
            _monitoringService = monitoringService;
            _emailService = emailService;
            _networkTokenService = networkTokenService;
            _otcService = otcService;
    }
        public async Task Execute(IJobExecutionContext context)
        {
            if (Common.IsTGEMonitorNeedToRun)
            {
                await _monitoringService.MonitorAddress();
                await _emailService.ProcessAllQueuedEmails();
                await _networkTokenService.UpdateHighAndLowPrice();
            }

            if (Common.IsOTCNeedToArchive)
            {
                await _otcService.ArchiveOTC(Common.OTCArchiveInHours);
            }
            await Task.CompletedTask;
        }
    }
}
