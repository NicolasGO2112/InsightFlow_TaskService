using Microsoft.AspNetCore.Mvc;
using TasksService.Dtos;
using TasksService.Models;
using TasksService.Repositories;

namespace TasksService.Controllers
{
    [ApiController]
    [Route("")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _repo;

        public TasksController(ITasksRepository repo)
        {
            _repo = repo;
        }

        // POST /tasks
        [HttpPost("tasks")]
        public IActionResult Create(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                DocumentId = dto.DocumentId,
                Title = dto.Title,
                Status = dto.Status,
                AssignedTo = dto.AssignedTo,
                DueDate = dto.DueDate
            };

            _repo.Create(task);
            return Created($"/tasks/{task.Id}", task);
        }

        // GET /documents/{documentId}/tasks
        [HttpGet("documents/{documentId}/tasks")]
        public IActionResult GetByDocument(Guid documentId)
        {
            return Ok(_repo.GetByDocument(documentId));
        }

        // GET /tasks/{id}
        [HttpGet("tasks/{id}")]
        public IActionResult GetById(Guid id)
        {
            var task = _repo.GetById(id);
            return task == null ? NotFound() : Ok(task);
        }

        // PATCH /tasks/{id}
        [HttpPatch("tasks/{id}")]
        public IActionResult Update(Guid id, UpdateTaskDto dto)
        {
            var updated = _repo.Update(id, new TaskItem
            {
                Title = dto.Title,
                Status = dto.Status,
                AssignedTo = dto.AssignedTo ?? Guid.Empty,
                DueDate = dto.DueDate ?? DateTime.MinValue
            });

            return updated == null ? NotFound() : Ok(updated);
        }

        // DELETE /tasks/{id}
        [HttpDelete("tasks/{id}")]
        public IActionResult Delete(Guid id)
        {
            bool deleted = _repo.SoftDelete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
