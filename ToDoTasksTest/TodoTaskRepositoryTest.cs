using ToDoTasks.Models;
using ToDoTasks.Repositories;

namespace ToDoTasksTest
{
    [TestClass]
    public class TodoTaskRepositoryTest
    {
        [TestCleanup]
        public void DeleteAllTasksFromRepo()
        {
            var repository = new TodoTaskRepository();

            var allTasks = repository.GetAllTodoTasks();

            foreach (var task in allTasks)
            {
                repository.DeleteTodoTask(task.Id);
            }
        }

        [TestMethod]
        public void AddTodoTask_AddOneTaskAndGetItById_SuccessfullyRetrieved()
        {
            var repository = new TodoTaskRepository();

            repository.AddTodoTask(new TodoTask
            {
                Name = "Test",
                Priority = 1,
                Status = Status.NotStarted
            });

            var task = repository.GetById(1);

            Assert.IsNotNull(task);
            Assert.AreEqual("Test", task.Name);
        }

        [TestMethod]
        public void AddTodoTask_AddMultipleTasksAndGetAll_SuccessfullyRetrieved()
        {
            var repository = new TodoTaskRepository();

            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 1",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 2",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 3",
                Priority = 1,
                Status = Status.NotStarted
            });

            var tasks = repository.GetAllTodoTasks();

            Assert.IsNotNull(tasks);
            Assert.AreEqual(3, tasks.Count());
        }

        [TestMethod]
        public void AddTodoTask_AddMultipleTasksAndGetByName_SuccessfullyRetrieved()
        {
            var repository = new TodoTaskRepository();

            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 1",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 2",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 3",
                Priority = 1,
                Status = Status.NotStarted
            });

            var task = repository.GetBy(t => t.Name.Equals("Test 2")).FirstOrDefault();

            Assert.IsNotNull(task);
            Assert.AreEqual("Test 2", task.Name);
        }

        [TestMethod]
        public void UpdateTodoTask_AddMultipleTasksUpdateOne_SuccessfullyUpdated()
        {
            var repository = new TodoTaskRepository();

            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 1",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 2",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 3",
                Priority = 1,
                Status = Status.NotStarted
            });

            var task = repository.GetBy(t => t.Name.Equals("Test 2")).FirstOrDefault();

            Assert.IsNotNull(task);

            task.Name = "Test 22";

            repository.UpdateTodoTask(task);
            task = repository.GetBy(t => t.Name.Equals("Test 22")).FirstOrDefault();

            Assert.IsNotNull(task);
            Assert.AreEqual("Test 22", task.Name);
        }

        [TestMethod]
        public void DeleteTodoTask_AddMultipleTasksDeleteOne_SuccessfullyDeleted()
        {
            var repository = new TodoTaskRepository();

            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 1",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 2",
                Priority = 1,
                Status = Status.NotStarted
            });
            repository.AddTodoTask(new TodoTask
            {
                Name = "Test 3",
                Priority = 1,
                Status = Status.NotStarted
            });

            var task = repository.GetBy(t => t.Name.Equals("Test 2")).FirstOrDefault();

            Assert.IsNotNull(task);

            repository.DeleteTodoTask(task.Id);
            
            task = repository.GetBy(t => t.Name.Equals("Test 2")).FirstOrDefault();

            Assert.IsNull(task);
        }
    }
}
