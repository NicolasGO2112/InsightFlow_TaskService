namespace TasksService.Dtos
{
    /// <summary>
    /// DTO (Data Transfer Object) para la actualización parcial de una tarea existente.
    /// Todas las propiedades son opcionales (nullable) para permitir actualizaciones selectivas.
    /// Solo se modificarán los campos que se proporcionen con valores no nulos.
    /// </summary>
    public class UpdateTaskDto
    {
        /// <summary>
        /// Nuevo título de la tarea. Si es null, el título no se modificará.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Nueva descripción de la tarea. Si es null, la descripción no se modificará.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Nuevo comentario o notas adicionales. Si es null, el comentario no se modificará.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Nuevo estado de la tarea (ej: "pendiente", "en progreso", "completada"). Si es null, el estado no se modificará.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Nuevo identificador del usuario asignado. Si es null, la asignación no se modificará.
        /// </summary>
        public Guid? AssignedTo { get; set; }

        /// <summary>
        /// Nueva fecha límite para completar la tarea. Si es null, la fecha límite no se modificará.
        /// </summary>
        public DateTime? DueDate { get; set; }
    }
}
