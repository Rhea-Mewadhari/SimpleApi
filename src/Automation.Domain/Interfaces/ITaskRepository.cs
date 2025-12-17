using Automation.Domain.Entities;

namespace Automation.Domain.Interfaces;

public interface ITaskRepository
{
    
    TaskResult Add(string Description);
    TaskResult? Get(string Id);

    IEnumerable<TaskResult> GetPending();

}