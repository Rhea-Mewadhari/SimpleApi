using Automation.Domain.Entities;

namespace Automation.Domain.Interfaces;

public interface ITaskValidator
{
    void Validate(CreateTaskRequest request);
}