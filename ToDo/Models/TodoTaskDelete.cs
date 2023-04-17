using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    public class TodoTaskDelete : TodoTask, IValidatableObject
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status != Models.Status.Completed)
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
