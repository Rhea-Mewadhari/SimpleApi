namespace Automation.Domain.Entities

{
    
    public class TaskResult(string id, string description)
    {
        public string Id = id;
        public string Description = description;
        public string Status = "Pending";
    }

}