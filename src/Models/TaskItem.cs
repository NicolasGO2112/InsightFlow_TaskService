using System;

namespace TasksService.Models
{
    /// <summary>
    /// Representa una tarea en el sistema InsightFlow.
    /// Modelo de dominio que contiene toda la información de una tarea individual,
    /// incluyendo asignación, fechas, estado y relación con documentos.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador del documento asociado a esta tarea.
        /// Permite vincular la tarea con un documento específico del sistema.
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Título breve y descriptivo de la tarea.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada de la tarea, objetivos y contexto.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Comentarios o notas adicionales sobre la tarea.
        /// Puede incluir observaciones, actualizaciones o instrucciones específicas.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Estado actual de la tarea (ej: "pendiente", "en progreso", "completada").
        /// Por defecto se inicializa en "pendiente".
        /// </summary>
        public string Status { get; set; } = "pendiente"; 

        /// <summary>
        /// Identificador único del usuario responsable de la tarea.
        /// </summary>
        public Guid AssignedTo { get; set; }

        /// <summary>
        /// Fecha límite para completar la tarea.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Indica si la tarea ha sido eliminada lógicamente del sistema.
        /// Permite soft-delete sin perder el registro histórico.
        /// Por defecto es false (no eliminada).
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
