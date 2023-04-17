using System.ComponentModel.DataAnnotations;
using ToDoTasks.Repositories;

namespace ToDoTasks.Models
{
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed
    }

    public class TodoTask : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Priority")]
        public uint? Priority { get; set; }

        [Display(Name = "Status")]
        public Status? Status { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (new TodoTaskRepository().GetBy(t => t.Id != Id && t.Name.Equals(Name)).Any())
            {
                return new ValidationResult[]
                {
                    new ValidationResult("Name is not Unique", new[] { "Name" }),
                };
            }
            return Array.Empty<ValidationResult>();
        }
    }
}
