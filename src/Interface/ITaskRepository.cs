using TasksService.Models;

namespace TasksService.Repositories
{
    public interface ITasksRepository
    {
        TaskItem Create(TaskItem task);
        IEnumerable<TaskItem> GetByDocument(Guid documentId);
        TaskItem? GetById(Guid id);
        TaskItem? Update(Guid id, TaskItem task);
        bool SoftDelete(Guid id);
    }
}
