using TasksService.Models;

namespace TasksService.Repositories
{
    /// <summary>
    /// Implementación en memoria del repositorio de tareas.
    /// Proporciona operaciones CRUD sobre TaskItem almacenando los datos en una lista en memoria.
    /// NOTA: Esta implementación es para desarrollo/pruebas. En producción debe reemplazarse
    /// por una implementación con persistencia real (SQL, NoSQL, etc.).
    /// </summary>
    public class TasksRepository : ITasksRepository
    {
        /// <summary>
        /// Almacén en memoria de las tareas. Los datos se pierden al reiniciar la aplicación.
        /// </summary>
        private readonly List<TaskItem> _tasks = new();

        /// <summary>
        /// Crea una nueva tarea y la agrega al almacén en memoria.
        /// </summary>
        /// <param name="task">La tarea a crear con todos sus datos iniciales.</param>
        /// <returns>La tarea creada (misma instancia recibida).</returns>
        public TaskItem Create(TaskItem task)
        {
            _tasks.Add(task);
            return task;
        }

        /// <summary>
        /// Obtiene todas las tareas no eliminadas asociadas a un documento específico.
        /// </summary>
        /// <param name="documentId">Identificador único del documento.</param>
        /// <returns>Colección de tareas vinculadas al documento que no están marcadas como eliminadas.</returns>
        public IEnumerable<TaskItem> GetByDocument(Guid documentId)
        {
            return _tasks.Where(t => t.DocumentId == documentId && !t.IsDeleted);
        }

        /// <summary>
        /// Busca una tarea no eliminada por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <returns>La tarea encontrada o null si no existe o está eliminada.</returns>
        public TaskItem? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
        }

        /// <summary>
        /// Actualiza una tarea existente con nueva información.
        /// Solo actualiza los campos que tengan valores válidos (no nulos, no vacíos).
        /// </summary>
        /// <param name="id">Identificador único de la tarea a actualizar.</param>
        /// <param name="data">Objeto con los datos actualizados. Los campos nulos o con valores por defecto no se actualizan.</param>
        /// <returns>La tarea actualizada o null si no se encontró la tarea con el id especificado.</returns>
        public TaskItem? Update(Guid id, TaskItem data)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
            if (task == null) return null;

            // Actualización parcial: solo modifica los campos con valores válidos
            task.Title = data.Title ?? task.Title;
            task.Description = data.Description ?? task.Description;
            task.Comment = data.Comment ?? task.Comment;
            task.Status = data.Status ?? task.Status;
            task.AssignedTo = data.AssignedTo != Guid.Empty ? data.AssignedTo : task.AssignedTo;
            task.DueDate = data.DueDate != DateTime.MinValue ? data.DueDate : task.DueDate;

            return task;
        }

        /// <summary>
        /// Elimina lógicamente una tarea marcándola como eliminada.
        /// La tarea permanece en el almacén pero se marca con IsDeleted = true.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a eliminar.</param>
        /// <returns>true si la eliminación fue exitosa; false si la tarea no fue encontrada.</returns>
        public bool SoftDelete(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            task.IsDeleted = true;
            return true;
        }
    }
}
