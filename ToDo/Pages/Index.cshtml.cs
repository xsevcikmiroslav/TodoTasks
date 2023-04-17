using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoTasks.Repositories.Interfaces;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITodoTaskRepository _todoTaskRepository; 

        public ITodoTaskRepository TodoTaskRepository => _todoTaskRepository;

        public IndexModel(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public void OnGet()
        { }
    }
}