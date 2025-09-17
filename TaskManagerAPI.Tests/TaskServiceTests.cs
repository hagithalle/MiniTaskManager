using System.Linq;
using TaskManagerAPI.Services;
using TaskManagerAPI.Models;
using Xunit;

namespace TaskManagerAPI.Tests
{
    public class TaskServiceTest
    {
        [Fact]
        public void add_ShouldAssignIdAndStoreTask()
        {
            var service = new TaskService();
            var task = new TaskItem { Title = "test", Description = "Desc" };

            var added = service.Add(task);

            Assert.Equal(1, added.Id);
            Assert.Single(service.GetAll());
        }

        [Fact]
        public void GetById_ShouldReturnCorrectTask()
        {
            var service = new TaskService();
            var task = service.Add(new TaskItem { Title = "T1" });

            var result = service.GetById(task.Id);

            Assert.NotNull(result);
            Assert.Equal("T1", result!.Title);
        }

        [Fact]
        public void Update_ShouldModifyExistingTask()
        {
            var service = new TaskService();
            var task = service.Add(new TaskItem { Title = "Old", Description = "Desc" });

            task.Title = "New";
            var Updated = service.Update(task);

            var result = service.GetById(task.Id);

            Assert.True(Updated);
            Assert.Equal("New", result!.Title);
        }


        [Fact]
        public void Delete_ShouldRemoveTask()
        {
            var service = new TaskService();
            var task = service.Add(new TaskItem { Title = "Deleted", Description = "Desc" });

            var deleted = service.Deleted(task.Id);

            Assert.True(deleted);
            Assert.Empty(service.GetAll());
        }

        [Fact]
        public void Delete_NoExistingTask_ShouldReturnFalse()
        {
            var service = new TaskService();
            var result = service.Deleted(999);

            Assert.False(result);
        }
    }
}