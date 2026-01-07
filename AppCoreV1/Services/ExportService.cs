using AppCoreV1.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppCoreV1.Services
{
    public class ExportService : BackgroundService
    {
        private bool _processing = false;
        private readonly ILogger<ExportService> _logger;
        //private Timer? _timer = null!;

        public ExportService(IServiceProvider services, ILogger<ExportService> logger)
        {
            Services = services;
            _logger = logger;
            _processing = false;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using(var scope = Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<IAbleSearch>();
                var _export = scope.ServiceProvider.GetRequiredService<IABLEExport>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    if (!_processing)
                    {
                        //Console.WriteLine("Processing " + DateTime.Now.ToString());

                        _processing = true;
                        var requests = await _context.SearchNewRequest("", "", 1, 25);

                        if (requests != null)
                        {
                            foreach (var request in requests)
                            {
                                _logger.LogError("Processing Request Created by " + request.UserId + " " + request.ReportName + " on " + request.DateRequested + " at " + DateTime.Now.ToString());

                                // update status
                                if (request.Status == "New")
                                {
                                    await _context.UpdateReportRequest(request.Id, 1);
                                }

                                switch (request.ReportName)
                                {
                                    case "RptAbleUser":
                                        await _export.RptAbleUser();
                                        await _context.UpdateReportRequest(request.Id, 2);
                                        break;
                                    case "RptAbleUserRole":
                                        await _export.RptAbleUserRole();
                                        await _context.UpdateReportRequest(request.Id, 2);
                                        break;
                                    case "RptActionService":
                                        await _export.RptActionService();
                                        await _context.UpdateReportRequest(request.Id, 2);
                                        break;
                                    case "RptCaseAction":
                                        await _export.RptCaseAction();
                                        await _context.UpdateReportRequest(request.Id, 2);
                                        break;
                                }
                            }
                        }
                    }
                    _processing = false;
                    Task.Delay(60000).Wait();
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogError("Consume Scoped Service Hosted Service is stopping.");
            await base.StopAsync(stoppingToken);
        }
    }
}
