using TasksService.Models;

namespace TasksService.Repositories
{
    /// <summary>
    /// Define el contrato para el repositorio de tareas.
    /// Abstrae las operaciones de persistencia y consulta de TaskItem,
    /// implementando el patrón Repository para desacoplar la lógica de negocio del acceso a datos.
    /// </summary>
    public interface ITasksRepository
    {
        /// <summary>
        /// Crea una nueva tarea en el sistema.
        /// </summary>
        /// <param name="task">La tarea a crear con todos sus datos iniciales.</param>
        /// <returns>La tarea creada con su identificador asignado.</returns>
        TaskItem Create(TaskItem task);

        /// <summary>
        /// Obtiene todas las tareas asociadas a un documento específico.
        /// </summary>
        /// <param name="documentId">Identificador único del documento.</param>
        /// <returns>Colección de tareas vinculadas al documento. Retorna colección vacía si no hay tareas.</returns>
        IEnumerable<TaskItem> GetByDocument(Guid documentId);

        /// <summary>
        /// Busca una tarea por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <returns>La tarea encontrada o null si no existe.</returns>
        TaskItem? GetById(Guid id);

        /// <summary>
        /// Actualiza una tarea existente con nueva información.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a actualizar.</param>
        /// <param name="task">Objeto con los datos actualizados de la tarea.</param>
        /// <returns>La tarea actualizada o null si no se encontró la tarea con el id especificado.</returns>
        TaskItem? Update(Guid id, TaskItem task);

        /// <summary>
        /// Elimina lógicamente una tarea marcándola como eliminada sin borrarla físicamente.
        /// Implementa el patrón soft-delete para mantener el registro histórico.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a eliminar.</param>
        /// <returns>true si la eliminación fue exitosa; false si la tarea no fue encontrada.</returns>
        bool SoftDelete(Guid id);
    }
}
