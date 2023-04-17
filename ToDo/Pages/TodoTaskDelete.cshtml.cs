using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoTasks.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Pages
{
    public class TodoTaskDeleteModel : PageModel
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IMapper _mapper;

        public TodoTaskDeleteModel(ITodoTaskRepository todoTaskRepository, IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            TodoTaskDelete = _mapper.Map<TodoTaskDelete>(_todoTaskRepository.GetById(id));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _todoTaskRepository.DeleteTodoTask(TodoTaskDelete.Id);

            return RedirectToPage("TodoTaskActionConfirmation", new { action = "deleted" });
        }

        [BindProperty]
        public TodoTaskDelete TodoTaskDelete { get; set; }
    }
}
