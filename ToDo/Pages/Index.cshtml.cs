using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoTasks.Repositories.Interfaces;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITodoTaskRepository _todoTaskRepository; 

        public ITodoTaskRepository TodoTaskRepository => _todoTaskRepository;

        public IndexModel(ILogger<IndexModel> logger, ITodoTaskRepository todoTaskRepository)
        {
            _logger = logger;
            _todoTaskRepository = todoTaskRepository;
        }

        public void OnGet()
        { }
    }
}