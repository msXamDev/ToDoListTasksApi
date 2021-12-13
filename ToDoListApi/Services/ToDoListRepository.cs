using ToDoListApi.Models;

namespace ToDoListApi.Services
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly List<TaskModel> _taskModel = new();
        private int _nextTask = 1;
        public ToDoListRepository()
        {
            AddTask(new TaskModel { ID = 1, Title = "Star Pattern", Description = "Console App to print Star Pattern", isDone = true });
            AddTask(new TaskModel { ID = 2, Title = "Find Factorial", Description = "Console App to find factorail of given number", isDone = true });
            AddTask(new TaskModel { ID = 3, Title = "Chess Board", Description = "C# Project to build a chess board in html", isDone = true });
            AddTask(new TaskModel { ID = 4, Title = "ToDoTask Api", Description = "ASP.NET core web api project", isDone = true });
        }
        public IEnumerable<TaskModel> GetTasks()
        {
            try
            {
                return _taskModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
        public TaskModel GetTaskByID(int id)
        {
            return _taskModel.Find(p => p.ID == id)!;
        }   
        public TaskModel AddTask(TaskModel task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            task.ID = _nextTask++;
            _taskModel.Add(task);            
            return task;
        }                         
        public void Remove(int id)
        {
            _taskModel.RemoveAll(p=> p.ID == id);
        }
        public bool Update(TaskModel task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            int index = _taskModel.FindIndex(p => p.ID == task.ID);

            if (index == -1)
                return false;

            _taskModel.RemoveAt(index);
            _taskModel.Add(task);

            return true;
        }
    }
}
