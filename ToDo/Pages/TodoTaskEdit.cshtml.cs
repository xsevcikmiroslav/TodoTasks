using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Pages
{
    public class TodoTaskEditModel : PageModel
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskEditModel(ITodoTaskRepository todoTaskRepository)
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

            _todoTaskRepository.UpdateTodoTask(TodoTask);

            return RedirectToPage("TodoTaskActionConfirmation", new { action = "edited" });
        }

        public IEnumerable<SelectListItem> Statuses => Helper.Statuses;

        [BindProperty]
        public TodoTask TodoTask { get; set; }
    }
}
