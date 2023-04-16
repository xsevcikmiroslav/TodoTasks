using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoTasks.Pages
{
    public class TodoTaskActionConfirmationModel : PageModel
    {
        public void OnGet(string action)
        {
            if (!string.IsNullOrEmpty(action))
            {
                Action = action;
            }
        }

        [BindProperty]
        public string Action { get; set; } = string.Empty;
    }
}
