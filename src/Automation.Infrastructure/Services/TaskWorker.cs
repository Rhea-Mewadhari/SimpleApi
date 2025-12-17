using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Automation.Domain.Interfaces;
using Automation.Domain.Entities;

namespace Automation.Infrastructure.Services;
public class TaskWorker( ITaskRepository repository, ITaskExecutor executor, IOptions<AutomationOptions> options,  ILogger<TaskWorker> logger) : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Task Worker started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            var pending = repository.GetPending().ToList();

            foreach (var task in pending)
            {
                
                logger.LogInformation("Processing task {TaskId}", task.Id);
                await executor.ExecuteAsync(task);

            }

            await Task.Delay(options.Value.WorkerDelayMs, stoppingToken);

        }

    }

}