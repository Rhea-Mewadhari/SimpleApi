
using Microsoft.AspNetCore.Mvc;
using Automation.Domain.Interfaces;
using Hangfire;

namespace Automation.Api.Controllers;

[ApiController]
[Route("jobs")]
public class JobsController(IEmailJob emailJob) : ControllerBase
{
    
    [HttpPost("welcome")]
    public IActionResult SendWelcome(string email)
    {

        BackgroundJob.Enqueue(() =>
            emailJob.SendWelcomEmail(email));

        return Ok("Job Enqueued");

    }

}