namespace TasksService.Dtos
{
    public class UpdateTaskDto
    {
        public string? Title { get; set; }
        public string? Status { get; set; }
        public Guid? AssignedTo { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
