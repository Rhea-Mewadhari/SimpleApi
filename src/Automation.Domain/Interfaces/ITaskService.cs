using Automation.Domain.Entities;

namespace Automation.Domain.Interfaces
{

    public interface ITaskService
    {
        TaskResult Create(string description);
        TaskResult? Get(string id);
    }
}