namespace TasksService.Dtos
{
    /// <summary>
    /// DTO (Data Transfer Object) para la creación de una nueva tarea en el sistema.
    /// Contiene todos los campos requeridos para inicializar una TaskItem.
    /// </summary>
    public class CreateTaskDto
    {
        /// <summary>
        /// Identificador único del documento asociado a la tarea.
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Título breve de la tarea.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada de la tarea.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Comentario o notas adicionales sobre la tarea.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Estado actual de la tarea. Por defecto "pendiente".
        /// </summary>
        public string Status { get; set; } = "pendiente";

        /// <summary>
        /// Identificador único del usuario al que se asigna la tarea.
        /// </summary>
        public Guid AssignedTo { get; set; }

        /// <summary>
        /// Fecha límite para completar la tarea.
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
