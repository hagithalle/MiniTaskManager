
namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TaskManagerAPI.Enums.TaskStatus Status { get; set; } = TaskManagerAPI.Enums.TaskStatus.Pending;
         }
}