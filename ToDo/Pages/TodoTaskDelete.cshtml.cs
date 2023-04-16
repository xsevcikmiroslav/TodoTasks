using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Pages
{
    public class TodoTaskDeleteModel : PageModel
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskDeleteModel(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public void OnGet(int id)
        {
            TodoTask = _todoTaskRepository.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _todoTaskRepository.DeleteTodoTask(TodoTask.Id);

            return RedirectToPage("TodoTaskActionConfirmation", new { action = "deleted" });
        }

        [BindProperty]
        public TodoTask TodoTask { get; set; }
    }
}
