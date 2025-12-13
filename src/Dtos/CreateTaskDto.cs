namespace TasksService.Dtos
{
    public class CreateTaskDto
    {
        public Guid DocumentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Status { get; set; } = "pendiente";
        public Guid AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
    }
}
