using ToDoListApi.Models;

namespace ToDoListApi.Services
{
    public interface IToDoListRepository
    {
        public IEnumerable<TaskModel> GetTasks();
        public TaskModel GetTaskByID(int id);
        public TaskModel AddTask(TaskModel task);
        public void Remove(int id);
        public bool Update(TaskModel task);
    }
}
