using System.ComponentModel.DataAnnotations;
using ToDo.Models;

namespace ToDoTasks.Models
{
    public class TodoTaskDelete : TodoTask
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status != ToDo.Models.Status.Completed)
            {
                return new ValidationResult[]
                {
                    new ValidationResult("Cannot delete task which is not Complete", new[] { "Status" }),
                };
            }
            return Array.Empty<ValidationResult>();
        }
    }
}
