namespace WorkerTests;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly int _waitingTimeSeconds;

    public Worker(ILogger<Worker> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _waitingTimeSeconds = configuration.GetValue<int>("WaitingTimeInSeconds");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(_waitingTimeSeconds * 1000, stoppingToken);
        }
    }
}
