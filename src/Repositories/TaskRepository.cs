using TasksService.Models;

namespace TasksService.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public TaskItem Create(TaskItem task)
        {
            _tasks.Add(task);
            return task;
        }

        public IEnumerable<TaskItem> GetByDocument(Guid documentId)
        {
            return _tasks.Where(t => t.DocumentId == documentId && !t.IsDeleted);
        }

        public TaskItem? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
        }

        public TaskItem? Update(Guid id, TaskItem data)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
            if (task == null) return null;

            task.Title = data.Title ?? task.Title;
            task.Status = data.Status ?? task.Status;
            task.AssignedTo = data.AssignedTo != Guid.Empty ? data.AssignedTo : task.AssignedTo;
            task.DueDate = data.DueDate != DateTime.MinValue ? data.DueDate : task.DueDate;

            return task;
        }

        public bool SoftDelete(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            task.IsDeleted = true;
            return true;
        }
    }
}
