using Automation.Domain.Interfaces;
using Automation.Domain.Entities;

namespace Automation.Infrastructure.Services;

public class BasicTaskExecutor() : ITaskExecutor
{
    
    public async Task ExecuteAsync(TaskResult task)
    {
        
        task.Status = "Running";
        await Task.Delay(1500); //fake work
        task.Status = "Completed";

    }

}