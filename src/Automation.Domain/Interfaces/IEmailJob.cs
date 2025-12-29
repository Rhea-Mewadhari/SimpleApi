
namespace Automation.Domain.Interfaces;

public interface IEmailJob
{
    Task SendWelcomEmail(string email);
}