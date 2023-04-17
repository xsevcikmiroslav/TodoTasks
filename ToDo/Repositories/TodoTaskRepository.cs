using ToDoTasks.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private static readonly IDictionary<int, TodoTask> _tasks = new Dictionary<int, TodoTask> { };

        public TodoTask GetById(int id)
        {
            return
                _tasks.Any() && _tasks.ContainsKey(id)
                ? _tasks[id]
                : null;
        }

        public IEnumerable<TodoTask> GetAllTodoTasks()
        {
            return _tasks.Values.AsEnumerable();
        }

        public IEnumerable<TodoTask> GetBy(Func<TodoTask, bool> predicate)
        {
            return _tasks.Values.Where(t => predicate(t));
        }

        public void AddTodoTask(TodoTask todoTask)
        {
            var id = _tasks.Any() ? _tasks.Keys.Max() + 1 : 1;
            todoTask.Id = id;
            _tasks[id] = todoTask;
        }

        public void UpdateTodoTask(TodoTask todoTask)
        {
            _tasks[todoTask.Id] = todoTask;
        }

        public void DeleteTodoTask(int id)
        {
            _tasks.Remove(id);
        }
    }
}
