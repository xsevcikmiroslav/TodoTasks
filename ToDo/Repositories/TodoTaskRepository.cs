using ToDo.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasks.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private static readonly IDictionary<int, TodoTask> _tasks = new Dictionary<int, TodoTask>
        {
            {
                1,
                new TodoTask
                {
                    Id = 1,
                    Name = "Task 1",
                    Priority = 5,
                    Status = Status.NotStarted
                }
            },
            {
                2,
                new TodoTask
                {
                    Id = 2,
                    Name = "Task 2",
                    Priority = 10,
                    Status = Status.Completed
                }
            },
            {
                3,
                new TodoTask
                {
                    Id = 3,
                    Name = "Task 3",
                    Priority = 1,
                    Status = Status.InProgress
                }
            },
        };

        public TodoTask GetById(int id)
        {
            return _tasks[id];
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
            var id = _tasks.Keys.Max() + 1;
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
