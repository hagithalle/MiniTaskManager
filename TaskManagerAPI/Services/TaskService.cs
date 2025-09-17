using System.Collections;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private readonly object _lock = new object();

        private int _nextId = 1;

        public IEnumerable GetAll()
        {
            lock (_lock)
            {
                {
                    return _tasks.ToList();
                }
            }
        }

        public TaskItem GetById(int id)
        {
            lock (_lock)
            {
                return _tasks.FirstOrDefault(t => t.Id == id);
            }


        }

        public TaskItem Add(TaskItem task)
        {
            lock (_lock)
            {
                task.Id = _nextId++;
                _tasks.Add(task);
                return task;
            }
        }

        public bool Update(TaskItem updatedTask)
        {
            lock (_lock)
            {
                var exitingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
                if (exitingTask == null) return false;

                exitingTask.Title = updatedTask.Title;
                exitingTask.Description = updatedTask.Description;
                exitingTask.Status = updatedTask.Status;
                return true;
            }
        }

        public bool Deleted(int id)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task == null) return false;

                _tasks.Remove(task);
                return true;
            }
        }

    }
}