namespace UserServiceApi.Dto.Request
{
    public class TaskCreateRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public string? Category { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
