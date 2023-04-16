using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.Models;

namespace ToDoTasks.Pages
{
    public static class Helper
    {
        public static IEnumerable<SelectListItem> Statuses =>
            Enum.GetValues<Status>()
            .Select(s => new SelectListItem { Text = s.ToString(), Value = ((int)s).ToString() })
            .Append(new SelectListItem { Text = "" })
            .OrderBy(s => s.Text);
    }
}
