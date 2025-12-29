using Automation.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Automation.Infrastructure.Services;

public class EmailJob(ILogger<EmailJob> logger) : IEmailJob
{
    
    public Task SendWelcomEmail(string email)
    {

     logger.LogInformation($"Sending welcome email to {email}");
     return Task.CompletedTask;   

    }

}