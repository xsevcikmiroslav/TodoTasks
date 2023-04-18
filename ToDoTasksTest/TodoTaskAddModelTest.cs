using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using ToDoTasks.Pages;
using ToDoTasks.Repositories.Interfaces;

namespace ToDoTasksTest
{
    // Unit testy na PageModely by mely byt v tomto duchu ??

    [TestClass]
    public class TodoTaskAddModelTest
    {
        private readonly Mock<ITodoTaskRepository> _mockRepository;

        public TodoTaskAddModelTest()
        {
            _mockRepository = new Mock<ITodoTaskRepository>();
        }

        [TestMethod]
        public void OnPost_ModelInvalid_IsNotRedirectedToConfirmPage()
        {
            var pageModel = new TodoTaskAddModel(_mockRepository.Object);
            pageModel.ModelState.Clear();
            pageModel.ModelState.AddModelError("Input Field", "Input field is required");

            var result = pageModel.OnPost();

            Assert.IsInstanceOfType(result, typeof(PageResult));;
        }

        [TestMethod]
        public void OnPost_ModelValid_IsNotRedirectedToConfirmPage()
        {
            var pageModel = new TodoTaskAddModel(_mockRepository.Object);
            pageModel.ModelState.Clear();
            
            var result = pageModel.OnPost();

            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult)); ;
        }
    }
}
