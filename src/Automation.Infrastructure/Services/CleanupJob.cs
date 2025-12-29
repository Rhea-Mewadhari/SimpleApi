using Automation.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Hangfire;

namespace Automation.Infrastructure.Services;

[AutomaticRetry(Attempts = 3)]
public class CleanupJob(ILogger<CleanupJob> logger) : ICleanupJob
{
    
    public Task Run()
    {
        
        logger.LogInformation("Running Cleanup Job");
        throw new InvalidOperationException("Simulated failure");

    }

}