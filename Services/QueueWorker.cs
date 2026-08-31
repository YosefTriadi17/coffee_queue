namespace CoffeeQueue.Services;

public class QueueWorker : BackgroundService
{
    private readonly ILogger<QueueWorker> _logger;

    public QueueWorker(ILogger<QueueWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("QueueWorker heartbeat at {time}", DateTimeOffset.Now);
            Console.WriteLine($"[{DateTimeOffset.Now:HH:mm:ss}] QueueWorker heartbeat");
            await Task.Delay(10000, stoppingToken);
        }
    }
}
