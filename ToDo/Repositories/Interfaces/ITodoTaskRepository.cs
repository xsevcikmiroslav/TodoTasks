using ToDoTasks.Models;

namespace ToDoTasks.Repositories.Interfaces
{
    public interface ITodoTaskRepository
    {
        TodoTask GetById(int id);

        IEnumerable<TodoTask> GetBy(Func<TodoTask, bool> predicate);

        IEnumerable<TodoTask> GetAllTodoTasks();

        void AddTodoTask(TodoTask todoTask);

        void UpdateTodoTask(TodoTask todoTask);

        void DeleteTodoTask(int id);
    }
}
