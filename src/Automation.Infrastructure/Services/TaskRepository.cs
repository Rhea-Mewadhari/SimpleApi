using Automation.Domain.Interfaces;
using Automation.Domain.Entities;

namespace Automation.Infrastructure.Services;

public class TaskRepository() : ITaskRepository
{
    
    private readonly Dictionary<string, TaskResult> _store = new();

    public TaskResult Add(string Description)
    {
        
        var id = Guid.NewGuid().ToString();
        var result = new TaskResult(id, Description);
        _store[id] = result;
        return result;

    }

    public TaskResult? Get(string id)
       => _store.TryGetValue(id, out var task) ? task : null;

    public IEnumerable<TaskResult> GetPending()
        => _store.Values.Where(x => x.Status == "Pending");

}