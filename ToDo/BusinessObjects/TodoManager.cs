using ToDo.Models;
using ToDoTasks.Repositories.Interfaces;

namespace ToDo.BusinessObjects
{
    public interface ITodoManager
    {
        void AddTodoTask(TodoTask todoTask);

        void DeleteTodoTask(TodoTask todoTask);

        IEnumerable<TodoTask> GetAllTodoTasks();

        void UpdateTodoTask(TodoTask todoTask);
    }

    public class TodoManager : ITodoManager
    {
        private readonly ITodoTaskRepository _repository;

        public TodoManager(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TodoTask> GetAllTodoTasks()
        {
            return _repository.GetAllTodoTasks();
        }

        public void AddTodoTask(TodoTask todoTask)
        {
            if (todoTask == null)
            {
                throw new Exception("TodoTask is null");
            }
            else if (string.IsNullOrEmpty(todoTask.Name))
            {
                throw new Exception("Name is empty");
            }

            _repository.AddTodoTask(todoTask);
        }

        public void UpdateTodoTask(TodoTask todoTask)
        {
            if (todoTask == null)
            {
                throw new Exception("TodoTask is null");
            }
            else if (string.IsNullOrEmpty(todoTask.Name))
            {
                throw new Exception("Name is empty");
            }

            _repository.UpdateTodoTask(todoTask);
        }

        public void DeleteTodoTask(TodoTask todoTask)
        {
            if (todoTask == null)
            {
                throw new Exception("TodoTask is null");
            }

            _repository.DeleteTodoTask(todoTask.Id);
        }
    }
}
