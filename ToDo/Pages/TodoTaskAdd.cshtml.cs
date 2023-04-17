using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoTasks.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Pages
{
    public class TodoTaskAddModel : PageModel
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskAddModel(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public void OnGet()
        { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _todoTaskRepository.AddTodoTask(TodoTask);

            return RedirectToPage("TodoTaskActionConfirmation", new { action = "added" });
        }

        public IEnumerable<SelectListItem> Statuses => Helper.Statuses;

        [BindProperty]
        public TodoTask TodoTask { get; set; }
    }
}
