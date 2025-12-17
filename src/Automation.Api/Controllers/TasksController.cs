using Automation.Domain.Interfaces;
using Automation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Automation.Api.Controllers;
[ApiController]
[Route("tasks")]
public class TaskController(ITaskService taskService, ITaskValidator validator) : ControllerBase
{
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateTaskRequest request)
    {
       validator.Validate(request);
        
        var result = taskService.Create(request.Description);
        return Ok(new { id = result.Id, status = result.Status });
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        
        var result = taskService.Get(id);
        return result is null ? NotFound() : Ok(new {id = result.Id, description = result.Description, status = result.Status});

    }

    [HttpGet("{id}/status")]
    public IActionResult GetStatus(string id)
    {
        
        var task = taskService.Get(id);
        return task is null ? NotFound() : Ok(new { id = task.Id, status = task.Status });

    }

}