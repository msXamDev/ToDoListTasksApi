namespace ToDoListApi.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool isDone { get; set; }
    }
}
