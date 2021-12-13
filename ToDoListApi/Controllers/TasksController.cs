using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoListApi.Models;
using ToDoListApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListApi.Controllers
{
    [Route("todo/api/v1.0/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        IToDoListRepository _repository;
        public TasksController(IToDoListRepository repository)
        {
            _repository = repository;
        }

        // GET: todo/api/V1.0/Tasks
        [HttpGet, ActionName("GetAllTasks")]
        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _repository.GetTasks();
        }

        // GET todo/api/V1.0/Tasks/id
        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetTaskByID(int id)
        {
            TaskModel task= _repository.GetTaskByID(id);
            if (task == null)
            {
                return NotFound($"Id \"{id}\" Not Found");
            }
            return task;
        }

        // POST todo/api/V1.0/Tasks
        [HttpPost]
        public List<TaskModel> PostTask([FromBody] TaskModel task)
        {
            List<TaskModel> TaskList=new List<TaskModel>();
            _ = _repository.AddTask(task);
            TaskList= _repository.GetTasks().ToList();
            return TaskList;
        }

        // PUT todo/api/V1.0/Tasks/id
        [HttpPut("{id}")]
        public ActionResult<List<TaskModel>> PutTask(int id, [FromBody] TaskModel task)
        {
            task.ID = id;
            var updateAction = _repository.Update(task);
            if (!updateAction)
            {
                return NotFound($"Id \"{id}\" Not Found");
            }
            return _repository.GetTasks().ToList();
        }

        // DELETE todo/api/V1.0/Tasks/id
        [HttpDelete("{id}")]
        public ActionResult<List< TaskModel>> DeleteTask(int id)
        {
            TaskModel task = _repository.GetTaskByID(id);
            if (task == null)
            {
                return NotFound($"Id \"{id}\" Not Found");
            }
            _repository.Remove(id);
            
            return _repository.GetTasks().ToList();
        }
    }
}
