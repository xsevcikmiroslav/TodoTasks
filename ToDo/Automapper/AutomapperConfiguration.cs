using AutoMapper;
using System.Net;
using ToDoTasks.Models;

namespace ToDoTasks.Automapper
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<TodoTask, TodoTaskDelete>().ReverseMap();
        }
    }
}
