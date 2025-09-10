
using TaskManagerAPI.Models;
using MyTaskStatus = TaskManagerAPI.Enums.TaskStatus;
using Xunit;


namespace TaskManagerAPI.Tests
{
    public class TaskItemTests
    {
        [Fact]
        public void CanCreateTaskItem_WithValidValues()
        {
            var task = new TaskItem
            {
                Id = 1,
                Title = "first check",
                Description = "create new object",
                Status = MyTaskStatus.Pending
            };

            Assert.Equal(1, task.Id);
            Assert.Equal("first check", task.Title);
            Assert.Equal("create new object", task.Description);
            Assert.Equal(MyTaskStatus.Pending, task.Status);
        }

        [Fact]
         
        public void TaskItem_DefaultStatus_ShouldBePending()
        {
            // Arrange
            var task = new TaskItem
            {
                Id = 2,
                Title = "Task without status",
                Description = "Chekeing Default Status"
                // Status לא הוגדר
            };

            // Assert
            Assert.Equal(MyTaskStatus.Pending, task.Status);
        }
    }
}