using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using ToDoTasks.Models;
using ToDoTasks.Pages;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasksTest
{
    [TestClass]
    public class TodoTaskAddModelTest
    {
        /*
        [TestMethod]
        public void OnPost()
        {
            var mockRepository = new Mock<ITodoTaskRepository>();
            mockRepository.Setup(m => m.GetAllTodoTasks()).Returns(new TodoTask[]
            {
                new TodoTask
                {
                    Id = 1,
                    Name = "Task 1",
                    Priority = 5,
                    Status = Status.NotStarted
                },
                new TodoTask
                {
                    Id = 2,
                    Name = "Task 2",
                    Priority = 10,
                    Status = Status.Completed
                },
                new TodoTask
                {
                    Id = 3,
                    Name = "Task 3",
                    Priority = 1,
                    Status = Status.InProgress
                }
            });

            var pageModel = new TodoTaskAddModel(mockRepository.Object);
            pageModel.TodoTask = new TodoTask();

            var result = pageModel.OnPost();

            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
        }*/
    }
}
