using Automation.Domain.Interfaces;
using Automation.Domain.Entities;

namespace Automation.Infrastructure.Services;

public class TaskService(ITaskRepository repository) : ITaskService
{

    public TaskResult Create(string description)
        => repository.Add(description);

    public TaskResult? Get(string id)
        => repository.Get(id);

}