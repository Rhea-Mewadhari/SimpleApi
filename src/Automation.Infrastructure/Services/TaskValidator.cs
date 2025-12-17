using Automation.Domain.Entities;
using Automation.Domain.Interfaces;

namespace Automation.Infrastructure.Services;

public class TaskValidator() : ITaskValidator
{
    
    public void Validate(CreateTaskRequest request)
    {
        
        if (string.IsNullOrWhiteSpace(request.Description))
            throw new ArgumentException("Task description cannot be empty.");

    }

}