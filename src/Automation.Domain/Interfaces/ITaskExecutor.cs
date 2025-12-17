using Automation.Domain.Entities;

namespace Automation.Domain.Interfaces;

public interface ITaskExecutor
{
    
    Task ExecuteAsync(TaskResult task);

}